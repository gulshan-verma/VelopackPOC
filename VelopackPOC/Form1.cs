using Velopack;

namespace VelopackPOC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateMyApp().GetAwaiter();
        }

        private static async Task UpdateMyApp()
        {
            var mgr = new UpdateManager("https://meramonitor.com/wp-content/uploads/download/MeraMonitorRelease/VelopackMigrationTesting/");

            // check for new version
            var newVersion = await mgr.CheckForUpdatesAsync();
            if (newVersion == null)
                return; // no update available

            // download new version
            await mgr.DownloadUpdatesAsync(newVersion);

            // install new version and restart app
            mgr.ApplyUpdatesAndRestart(newVersion);
        }
    }
}
