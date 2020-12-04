using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System.IO;

namespace ConnexionSFTP
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>

        
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
        }

        static void connect()
        {
            string host = @"apptech-sftp.ces-incendie.fr";
            string username = "ces";
            PrivateKeyFile keyFile = new PrivateKeyFile(@"path/to/OpenSsh-RSA-key.ppk");
            var keyFiles = new[] { keyFile };

            var methods = new List<AuthenticationMethod>();
            methods.Add(new PrivateKeyAuthenticationMethod(username, keyFiles));

            ConnectionInfo con = new ConnectionInfo(host, 22, username, methods.ToArray());
            using (var client = new SftpClient(con))
            {
                client.Connect();
                Console.WriteLine("Connexion établie avec succès");
                // Do what you need with the client !

                //client.Disconnect();
            }
        }

    }
}
