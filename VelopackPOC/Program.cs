using System.Reflection.Metadata;
using Velopack;

namespace VelopackPOC
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            VelopackApp.Build()
                .WithAfterUpdateFastCallback(x => CreateMeraMonitorCommonFolder())
                .WithFirstRun(x => CreateMeraMonitorCommonFolder())
                .Run();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        private static void CreateMeraMonitorCommonFolder()
        {
            var parentScreenShotInstallationPath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName,
                                                                "Screenshot");

            var parentLogOfflineInstallationPath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName,
                                                                "LogOffline");

            if (!Directory.Exists(parentScreenShotInstallationPath))
            {
                Directory.CreateDirectory(parentScreenShotInstallationPath);
            }

            if (!Directory.Exists(parentLogOfflineInstallationPath))
            {
                Directory.CreateDirectory(parentLogOfflineInstallationPath);
            }
        }
    }
}