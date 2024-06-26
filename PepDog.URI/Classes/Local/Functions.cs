using LambdaBlox.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LambdaBloxURI.Local {
    class Functions {
        public static void RegisterURI(Form form) {
            if(SecurityFuncs.IsElevated) {
                try {
                    URIRegister uri = new URIRegister("lambdablox", "url.lambdablox");
                    uri.Register();
                    if(Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".lambdablox"))) {
                        Directory.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".lambdablox"), true);
                    }
                    
                    MessageBox.Show("URI successfully installed and registered!", "LambdaBlox - Install URI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Windows.Forms.Application.Exit();
                } catch (Exception ex) {
                    MessageBox.Show("Failed to register. (Error: " + ex.Message + ")", "LambdaBlox - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    form.Close();
                    System.Windows.Forms.Application.Exit();
                }
            } else {
                MessageBox.Show("Failed to register. (Error: Did not run as Administrator)", "LambdaBlox - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form.Close();
                System.Windows.Forms.Application.Exit();
            }

        }

        public static void SetupURIValues(Form form) {
            string holder = Variables.SharedArgs.Replace("lambdablox://", "");
            if(holder.EndsWith("/")) {
                holder = holder.Remove(holder.Length - 1);
            }
            string decoded = Base64Decode(holder);

            string[] split = decoded.Split(',');
            for (int i = 0; i < split.Length; i++) {
                split[i] = split[i].Replace(",", "");
            }

            string ip = split[0].Split(':')[1];
            Variables.ip = ip;

            string port = split[1].Split(':')[1];
            Variables.port = int.Parse(port);

            string name = split[2].Split(':')[1];
            Variables.name = name;

            string color_raw = split[3].Split(new string[] { "colors:" }, StringSplitOptions.None)[1].Replace(":",",");
            Variables.colors = color_raw;

            var process = new Process {
                StartInfo = {
                    FileName = Path.Combine(System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName),"LambdaBloxApp.exe"),
                    Arguments = "-script \"dofile('http://afs.gurdit.com/download/connect.lua') start('"+Variables.ip+"',"+Variables.port+",'"+Variables.name+"',"+Variables.colors+")\""
                }
            };
            process.Start();
            System.Windows.Forms.Application.Exit();
        }
        public static string Base64Encode(string plainText) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData) {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
