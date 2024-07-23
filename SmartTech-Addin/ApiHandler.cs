using Microsoft.Office.Interop.Outlook;
using SmartTech_Addin.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

using Outlook = Microsoft.Office.Interop.Outlook;

namespace SmartTech_Addin
{
    internal class ApiHandler
    {
        private LoaderForm form;
        private string url = "http://ec2-23-22-34-167.compute-1.amazonaws.com:52991";
        private string curlExePath = "C:\\Windows\\System32\\curl.exe";

        Process commandProcess = null;

        public ApiHandler() { }

        private (string, string) GetSelecteEmailTempSavedPath(MailItem mailItem)
        {
            string tempPath = null;
            string uuid = Guid.NewGuid().ToString();

            if (mailItem != null)
            {
                tempPath = Path.Combine(Path.GetTempPath(), uuid + ".msg");
                mailItem.SaveAs(tempPath, Outlook.OlSaveAsType.olMSG);
            }
            return (tempPath, uuid.Substring(0, 6));
        }

        public string getAiSuggestResponse(MailItem mail)
        {
            try
            {
                form = new LoaderForm();
                form.Show();

                var (path, rdStr) = GetSelecteEmailTempSavedPath(mail);
                string curlCmdAiSuggest = $"curl -X POST -H \"Content-Type: multipart/form-data\" -H \"fileref: {rdStr}\" -F file=@\"{path}\" {url}/processmsg";
                return ExecuteCommand(curlCmdAiSuggest);
            }
            finally
            {
                form.Close();
                form = null;
            }
        }

        public string getAiSummarize(MailItem mail)
        {
            try
            {
                form = new LoaderForm();
                form.Show();

                var (path, rdStr) = GetSelecteEmailTempSavedPath(mail);
                string curlCmdAiSuggest = $"curl -X POST -H \"Content-Type: multipart/form-data\" -H \"fileref: {rdStr}\" -F file=@\"{path}\" {url}/summarize";
                return ExecuteCommand(curlCmdAiSuggest);
            }
            finally
            {
                form.Close();
                form = null;
            }
        }

        public string getRepharse(string emailBody)
        {
            try
            {
                form = new LoaderForm();
                form.Show();
                string curlCmdAiSuggest = $"curl -X POST -H \"Content-Type: multipart/form-data\" -F \"rephraseText={emailBody}\" {url}/rephrase";
                return ExecuteCommand(curlCmdAiSuggest);
            }
            finally
            {
                form.Close();
                form = null;
            }
        }

        private string ExecuteCommand(string commandLineArguments)
        {
            commandProcess = new Process();
            commandProcess.StartInfo.UseShellExecute = false;
            commandProcess.StartInfo.FileName = curlExePath; // this is the path of curl where it is installed;    
            commandProcess.StartInfo.Arguments = commandLineArguments; // your curl command    
            commandProcess.StartInfo.CreateNoWindow = true;
            commandProcess.StartInfo.RedirectStandardInput = false;
            commandProcess.StartInfo.RedirectStandardOutput = true;
            commandProcess.StartInfo.RedirectStandardError = true;
            commandProcess.StartInfo.StandardOutputEncoding = System.Text.Encoding.UTF8;
            commandProcess.Start();

            string response = "";
            string error = "";
            while (!commandProcess.HasExited)
            {
                response += commandProcess.StandardOutput.ReadToEnd();
                error += commandProcess.StandardError.ReadToEnd();
            }
            commandProcess.WaitForExit();
            commandProcess.Close();

            string finalResult = "";
            if (String.IsNullOrEmpty(response) || String.IsNullOrEmpty(error))
            {
                finalResult = "Response is not comming from Bedrock";
            }
            else if (String.IsNullOrEmpty(response))
            {
                finalResult = error;
            }
            else
            {
                finalResult = response;
            }

            string message = parse(finalResult);
            return message;
        }

        private string parse(string text)
        {
            if (text.StartsWith("\""))
                text = text.Substring(1);
            if (text.EndsWith("\"\n"))
                text = text.Substring(0, text.Length - 2);
            return Regex.Replace(text, @"(\r\n|\r|\\n)", "\n");
        }
    }
}
