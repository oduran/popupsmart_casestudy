using IntegrationService.Business;
using IntegrationService.Helpers;
using IntegrationService.Items;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace IntegrationService
{
    public class Worker : BackgroundService
    {

        private static IntegrationBusiness bus;
        private static System.Timers.Timer timer; // name space(using System.Timers;)
        private static TimerConfigsItem timerConfigs;

        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            timerConfigs = ConfigurationHelper.GetTimerConfigs();

            int timerElapsedSecond = Convert.ToInt32(timerConfigs.TimerIntervalSecond); // App.configdeki timerINtervalSecond parametresi
            bus = new IntegrationBusiness();
            timer = new System.Timers.Timer();
            timer.Interval = timerElapsedSecond * 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(10000, stoppingToken);
            }

        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Stop();

            //ramde yaşayan ilk 100 data çekilip sonra bitince tekrar çek
            var res1 = bus.GetTopNRows();
            int n = res1.Count();

            Console.WriteLine($"{n} rows in progress {DateTime.Now}");

            for (int i = 0; i < n; i++)
            {
                var res =  bus.SendData(res1[i]).Result;

                if (res.Item1)
                {
                    // true ise...
                }
                else
                {
                    // data gönderilemedi ise...
                    //TODO : Exceptionları file systeme log atılabilir.
                }

                // yığılmayı engellemek için  appsettings timerWaitSecond parametresine göre sleep ediyor.

                System.Threading.Thread.Sleep((Convert.ToInt32(timerConfigs.TimerWaitSecond)) * 1000);
            }

            timer.Start();
        }
    }
}