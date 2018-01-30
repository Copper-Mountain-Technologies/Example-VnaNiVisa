// Copyright ©2018 Copper Mountain Technologies
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR
// ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

// IMPORTANT: The following two Visa library references must be added to the project as follows:
// References > Right-Click > Add Reference... > Browse > then select the following two dlls:
//
//      - C:\Program Files (x86)\IVI Foundation\VISA\Microsoft.NET\Framework32\v4.0.30319\NI VISA.NET 15.5/NationalInstruments.Visa.dll
//      - C:\Program Files (x86)\IVI Foundation\VISA\Microsoft.NET\Framework32\v2.0.50727\VISA.NET Shared Components 5.7.0/Ivi.Visa.dll
//      (note that the version numbers on your system may be different than shown here)

using Ivi.Visa;
using NationalInstruments.Visa;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace VNA_Visa_Example
{
    public partial class FormMain : Form
    {
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private MessageBasedSession visaMessageBasedSession;
        private VisaAsyncCallback visaAsyncCallback = null;
        private IVisaAsyncResult visaAsyncResult = null;

        // ------------------------------------------------------------------------------------------------------------

        private string selectedVisaResourceName = "";
        private bool isVnaConnected = false;

        // ------------------------------------------------------------------------------------------------------------

        private delegate void appendToTextBoxLogVnaCallback(string s);

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        public FormMain()
        {
            InitializeComponent();

            // --------------------------------------------------------------------------------------------------------

            // set form icon
            // Icon = Properties.Resources.app_icon;

            // set program name
            Text = Program.programName;

            // disable resizing the plug-in window
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = true;

            // position in the center of the screen
            CenterToScreen();

            // --------------------------------------------------------------------------------------------------------

            // set version label text
            toolStripStatusLabelVersion.Text = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

            // --------------------------------------------------------------------------------------------------------

            // init visa resource name combo box
            initVisaResourceNameComboBox();

            // init ui
            updateUi(isVnaConnected);

            // this setting causes the log text box to auto-scroll
            richTextBoxLogVna.HideSelection = false;

            // create an async visa callback for receiving data from the vna
            visaAsyncCallback = new VisaAsyncCallback(receiveAsyncDataFromVnaThruVisa);
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void initVisaResourceNameComboBox()
        {
            // clear existing items
            comboBoxVisaResourceName.Items.Clear();

            // use a resource manager
            using (var visaResourceManager = new ResourceManager())
            {
                {
                    // find VISA resources
                    var resources = visaResourceManager.Find("(ASRL|GPIB|TCPIP|USB)?*"); // "?*INSTR" or "(ASRL|GPIB|TCPIP|USB)?*"

                    // populate combo box
                    foreach (string s in resources)
                    {
                        comboBoxVisaResourceName.Items.Add(s);
                    }
                }
            }

            // set the default combo box selection
            if ((selectedVisaResourceName != null) &&
                (comboBoxVisaResourceName.Items.Contains(selectedVisaResourceName)))
            {
                comboBoxVisaResourceName.SelectedItem = selectedVisaResourceName;
            }
            else
            {
                if (comboBoxVisaResourceName.Items.Count > 0)
                {
                    comboBoxVisaResourceName.SelectedIndex = 0;
                }
            }
        }

        // ============================================================================================================

        private void comboBoxVisaResourceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVisaResourceName.SelectedItem is string)
            {
                // update selected value
                selectedVisaResourceName = (string)comboBoxVisaResourceName.SelectedItem;
            }
            else
            {
                // update selected value
                selectedVisaResourceName = null;
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void buttonConnectDisconnectVna_Click(object sender, EventArgs e)
        {
            // is there a connection to the vna?
            if (isVnaConnected == true)
            {
                // yes...

                // close connection to vna
                disconnectVna();
            }
            else
            {
                // no...

                // connect thru visa with the name selected in the dialog
                connectVna();
            }

            // update ui
            updateUi(isVnaConnected);
        }

        // ============================================================================================================

        private void updateUi(bool connected)
        {
            if (connected == true)
            {
                // update connect/disconnect button
                buttonConnectDisconnectVna.Text = "Disconnect";

                // disable visa resource name combo box
                comboBoxVisaResourceName.Enabled = false;

                // enable command panel
                groupBoxCommand.Enabled = true;
            }
            else
            {
                // update connect/disconnect button
                buttonConnectDisconnectVna.Text = "Connect";

                // enable visa resource name combo box
                comboBoxVisaResourceName.Enabled = true;

                // disable command panel
                groupBoxCommand.Enabled = false;

                // clear command text box
                textBoxCommand.Text = "";
            }

            // update connected status
            toolStripStatusLabelText.Text = connected ? "Connected" : "Not Connected";
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void connectVna()
        {
            // is there a connection to the vna?
            if (isVnaConnected == false)
            {
                // no...

                // make sure we have a visa name
                if (selectedVisaResourceName.Length > 0)
                {
                    // disable ui
                    this.Enabled = false;

                    // force ui update
                    Application.DoEvents();

                    // change to wait cursor
                    Cursor.Current = Cursors.WaitCursor;

                    // use a resource manager
                    using (var visaResourceManager = new ResourceManager())
                    {
                        try
                        {
                            // open the visa session
                            visaMessageBasedSession = (MessageBasedSession)visaResourceManager.Open(selectedVisaResourceName);

                            // set timeout (must be set no less than the maximum expected sweep time)
                            visaMessageBasedSession.TimeoutMilliseconds = 60000; // note: default is 2 seconds (2000 ms)

                            // enable termination character
                            visaMessageBasedSession.TerminationCharacter = 10; // line feed
                            visaMessageBasedSession.TerminationCharacterEnabled = true;

                            // update vna connected flag
                            isVnaConnected = true;

                            // log the event
                            appendToTextBoxLog("Connected to VNA thru VISA");
                        }
                        catch (InvalidCastException e)
                        {
                            // update vna connected flag
                            isVnaConnected = false;

                            // show exception error message
                            MessageBox.Show("Selected resource must be a message-based session." +
                                            e.Message,
                                            Program.programName,
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                            // log the error
                            appendToTextBoxLog("Error Connecting thru VISA to VNA at: " + selectedVisaResourceName);
                        }
                        catch (Exception e)
                        {
                            // update vna connected flag
                            isVnaConnected = false;

                            // show exception error message
                            MessageBox.Show("Unable to connect to the VNA. Please verify the following:\n\n" +
                                            "The Socket Server on the VNA software must be ON.\n(System > Misc Setup > Network Setup > Socket Server > ON)\n\n" +
                                            "The VNA IP address must be correct.\n(typically the IP of the PC running the VNA software)\n\n" +
                                            "The VNA Port must match the VNA software.\n(System > Misc Setup > Network Setup > TCP/IP Port)\n\n" +
                                            e.Message,
                                            Program.programName,
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                            // log the error
                            appendToTextBoxLog("Error Connecting thru VISA to VNA at: " + selectedVisaResourceName);
                        }
                    }

                    // change to default cursor
                    Cursor.Current = Cursors.Default;

                    // enable ui
                    this.Enabled = true;
                }
                else
                {
                    // update vna connected flag
                    isVnaConnected = false;
                }
            }
        }

        // ============================================================================================================

        private void disconnectVna()
        {
            // is there a connection to the vna?
            if (isVnaConnected == true)
            {
                // yes...
                visaMessageBasedSession.Dispose();

                // update vna connected flag
                isVnaConnected = false;

                // log the event
                appendToTextBoxLog("Disconnected from VNA" + Environment.NewLine);
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void appendToTextBoxLog(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                // NOTE: the following is needed to make a thread-safe call
                // InvokeRequired compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (!this.IsDisposed)
                {
                    if (this.richTextBoxLogVna.InvokeRequired)
                    {
                        appendToTextBoxLogVnaCallback d = new appendToTextBoxLogVnaCallback(appendToTextBoxLog);

                        try
                        {
                            this.BeginInvoke(d, new object[] { s });
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        // append time stamp, text string, and new line
                        richTextBoxLogVna.AppendText(DateTime.Now.ToString("hh:mm:ss tt") + ": " + s + Environment.NewLine);
                    }
                }
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void sendDataToVnaThruVisa(string s)
        {
            try
            {
                // send the data (append CR+LF)
                visaMessageBasedSession.RawIO.Write(s + "\r\n");

                // log the data sent to the VNA
                appendToTextBoxLog(">> " + s);

                // is this a query
                if (s.EndsWith("?"))
                {
                    // yes...

                    // read the response string from the vna
                    s = visaMessageBasedSession.FormattedIO.ReadUntilEnd();

                    // remove carriage return, line feed, and null characters if they exist
                    s = s.Replace("\n", "").Replace("\r", "").Replace("\0", "");

                    // was any data received?
                    if (!string.IsNullOrEmpty(s))
                    {
                        // yes...

                        // log the data received from the vna
                        appendToTextBoxLog("<< " + s);
                    }
                }
            }
            catch (Exception e)
            {
                // log the error
                appendToTextBoxLog("Error Sending Data to VNA: " + e.Message);
            }
        }

        // ============================================================================================================

        // NOTE: The following function is only for if you need to receive data asynchronously from the vna without
        // first sending data to it.
        public void receiveAsyncDataFromVnaThruVisa(IVisaAsyncResult result)
        {
            try
            {
                // read the data
                string s = visaMessageBasedSession.RawIO.EndReadString(result);

                // remove carriage return, line feed, and null characters if they exist
                s = s.Replace("\n", "").Replace("\r", "").Replace("\0", "");

                // was any data received?
                if (!string.IsNullOrEmpty(s))
                {
                    // yes...

                    // log the data received from vna
                    appendToTextBoxLog("<< " + s);
                }

                // begin next asynchronous read from vna
                visaAsyncResult = visaMessageBasedSession.RawIO.BeginRead(1024, visaAsyncCallback, null);
            }
            catch (Exception e)
            {
                // log the error
                appendToTextBoxLog("Error Receiving Data from the VNA: " + e.Message);
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void buttonCmdIdn_Click(object sender, EventArgs e)
        {
            sendDataToVnaThruVisa("*IDN?");
        }

        private void buttonCmdOpc_Click(object sender, EventArgs e)
        {
            sendDataToVnaThruVisa("*OPC?");
        }

        private void buttonCmdCls_Click(object sender, EventArgs e)
        {
            sendDataToVnaThruVisa("*CLS");
        }

        private void buttonCmdRst_Click(object sender, EventArgs e)
        {
            sendDataToVnaThruVisa("*RST");
        }

        private void buttonCmdSystErr_Click(object sender, EventArgs e)
        {
            sendDataToVnaThruVisa("SYST:ERR?");
        }

        // ============================================================================================================

        private void buttonSend_Click(object sender, EventArgs e)
        {
            sendDataToVnaThruVisa(textBoxCommand.Text);
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // close connection to vna
            if (isVnaConnected == true)
            {
                // yes...
                visaMessageBasedSession.Dispose();
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    }
}