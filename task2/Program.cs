using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;





namespace Start
{
    class Program
    {
        static void Main(string[] args)
        {

            
            using (var client = new MySolution.ServiceReference.Service1Client())
            {


                // Чтение
                List<String> arrayStr = new List<String>();
                StreamReader sr = new StreamReader("input.text");
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    arrayStr.Add(str);

                }
                sr.Close();


                //     Отправляем на сервер, где есть статическая переменная по 5000 строк из файла - это позволит читать файлы очень больших размеров, но не есть хороший способ           
                StringBuilder stringBuilderText = new StringBuilder();
                sr = new StreamReader("input.text");
                int numbersStr = 0;
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    stringBuilderText.Append(str.ToString() + "\n");
                    numbersStr++;
                    if(numbersStr>= 5000)
                    {
                        client.addStr(stringBuilderText.ToString());
                        numbersStr = 0;
                        stringBuilderText.Clear();
                    }

                }
                sr.Close();
                client.addStr(stringBuilderText.ToString());



                WordProcessing.FlowsProcessing flowsProcessing = new WordProcessing.FlowsProcessing();
                Stopwatch stopwatchParallDll = new Stopwatch();

                // обычный вызов из ДЛЛ без сервиса
                stopwatchParallDll.Start();
                var parallDictionaryDll = flowsProcessing.ParallFlow(arrayStr);
                stopwatchParallDll.Stop();



                Stopwatch stopwatchParallService = new Stopwatch();
                var dictionaryParallService = new Dictionary<string, int>();


                stopwatchParallService.Start();

                // вызов метода сервиса, текст был передан выше
                dictionaryParallService = client.ParallProcessing();
                
                stopwatchParallService.Stop();


                // Запись в файл
                var sortParallDictionaryDll = parallDictionaryDll.OrderByDescending(u => u.Value);

                StreamWriter sw = new StreamWriter("output1.text");
                sw.WriteLine(stopwatchParallDll.Elapsed);
                foreach (var item in sortParallDictionaryDll)
                {
                    sw.WriteLine(item.Key + " " + item.Value);
                }

                sw.Close();


                var sortDictionaryParallService = dictionaryParallService.OrderByDescending(u => u.Value);

                sw = new StreamWriter("output2.text");
                sw.WriteLine(stopwatchParallService.Elapsed);
                foreach (var item in sortDictionaryParallService)
                {
                    sw.WriteLine(item.Key + " " + item.Value);
                }

                sw.Close();

                
            }



            // В случае если ффайл нне очень больших объемов, можно воспользоваться кодом ниже 


            /*
                      
            StringBuilder stringBuilderText1 = new StringBuilder();
            StreamReader sr = new StreamReader("input.text");
            string stringText = "";



            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                stringBuilderText1.Append(sr);
            }
            sr.Close();

            stringText = stringBuilderText1.ToString();

            var dictionaryService1 = new Dictionary<string, int>();

            using(var client = new MySolution.ServiceReference.Service1Client())
            {
                dictionaryService1 = client.ParallProcessingStr(stringText);
            }



            var sortDictionaryParallService1 = dictionaryService1.OrderByDescending(u => u.Value);

            StreamWriter sw1 = new StreamWriter("output3.text");
            
            foreach (var item in sortDictionaryParallService1)
            {
                sw1.WriteLine(item.Key + " " + item.Value);
            }

            sw1.Close();

    */

        }


    }
}
