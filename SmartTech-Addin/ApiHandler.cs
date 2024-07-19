using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Outlook = Microsoft.Office.Interop.Outlook;

namespace SmartTech_Addin
{
    internal class ApiHandler
    {
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
            var (path, rdStr) = GetSelecteEmailTempSavedPath(mail);
            string curlCmdAiSuggest = $"curl -X POST -H \"Content-Type: multipart/form-data\" -H \"fileref: {rdStr}\" -F file=@\"{path}\" {url}/image";
            return ExecuteCommand(curlCmdAiSuggest);
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

            return finalResult;
        }
    }
}
