#define AllowTest

#if AllowTest
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace InfinityScript
{
    public class TestScript : BaseScript
    {
        public TestScript()
        {
            TestAfterDelay();
            TestOnInterval();
            TestAsync();

           /* Notified += new Action<int, string, Parameter[]>((entRef, notify, parameters) =>
            {
                Log.Info("###########################");
                Log.Info("Notified");
                Log.Info($"Ent called notify: {entRef}");
                Log.Info($"Notify name: {notify}");
                Log.Info($"Sended parameters: {string.Join(" ", parameters.Select(x => x.ToString()).ToArray())}");
                Log.Info("###########################");
            }); */
        }

        public void TestOnInterval()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int maxInteration = 5;
            
            // That not delay, first interation may be fast (time < 500ms)
            OnInterval(1500, () =>
            {
                Log.Info("########################");
                Log.Info("Interval 1.5 sec");
                Log.Info($"Interval time: {stopwatch.ElapsedMilliseconds}");
                Log.Info("########################");
                stopwatch.Restart();
                maxInteration--;
                return maxInteration != 0;
            });
        }

        public void TestAfterDelay()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            AfterDelay(10000, () =>
            {
                Log.Info("########################");
                Log.Info("AfterDelay 10 seconds");
                Log.Info($"After delay time: {stopwatch.ElapsedMilliseconds}");
                Log.Info("########################");

                stopwatch.Stop();
            });
        }

        public void TestAsync()
        {
            StartAsync(Async_1(), new string[] { "stop_async_1" });
            StartAsync(Async_2());

            AfterDelay(15000, () => Notify("stop_async_1"));
        }

        public IEnumerator Async_1()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (true)
            {
                yield return Wait(2.5f);
                Log.Info("########################");
                Log.Info("IEnumerator Wait 2.5 seconds");
                Log.Info($"Real used time: {stopwatch.ElapsedMilliseconds}");
                Log.Info("########################");
                stopwatch.Restart();
            }
        }

        public IEnumerator Async_2()
        {
            while (true)
            {
                yield return WaitTill("prematch_done");

                Log.Info("########################");
                Log.Info("Prematch done complited!");
                Log.Info("########################");

                yield break;
            }
        }
    }
}
#endif