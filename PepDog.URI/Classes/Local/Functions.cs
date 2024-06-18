using LambdaBlox.Core;
using LambdaBloxURI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LambdaBloxURI.Local {
    class Functions {
        public static void RegisterURI(Form form) {
            if(SecurityFuncs.IsElevated) {
                try {
                    URIRegister uri = new URIRegister("lambdablox", "url.lambdablox");
                    uri.Register();

                    //MessageBox.Show("URI successfully installed and registered!", "LambdaBlox - Install URI", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            string client = "L2008";

            var process = new Process {
                StartInfo = {
                    FileName = System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".lambdablox"), "client"), client),"LambdaBloxApp.exe"),
                    Arguments = "-script \"dofile('rbxasset://scripts/StartPlayer.lua') start('"+Variables.ip+"',"+Variables.port+",'"+Variables.name+"',"+Variables.colors+")\""
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
