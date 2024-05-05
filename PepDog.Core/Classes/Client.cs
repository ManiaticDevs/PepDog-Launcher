using System.Diagnostics;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PepDog.Core {
    public class Client {
        public static bool HasJava8() {
            string regexPattern = @"([0-9]+)";
            Regex regex = new Regex(regexPattern);
            int value = -1;
            if(GetJavaVersion() != null) {
                value = int.Parse(regex.Matches(GetJavaVersion())[1].Value);
            }
            return value == 8;
        }

        private static String GetJavaVersion() {
            try {
                ProcessStartInfo procStartInfo =
                    new ProcessStartInfo("java", "-version ");

                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.RedirectStandardError = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                return proc.StandardError.ReadLine();

            } catch (Exception objException) {
                return null;
            }
        }
    }
}