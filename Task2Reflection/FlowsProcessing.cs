using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections.Concurrent;


namespace WordProcessing
{
    public class FlowsProcessing
    {
               
        
        Dictionary<String, int> OneFlow(string strings)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            var arrayStr = strings.Split('\n');

            foreach (var str in arrayStr)
            {

                Regex regex = new Regex(@"[A-zА-я]*");
                var regexStr = regex.Matches(str);


                foreach (var item in regexStr)
                {
                                        
                    if (item.ToString() != "")
                    {
                        if (dictionary.ContainsKey(item.ToString()))
                        {
                            dictionary[item.ToString()] = dictionary[item.ToString()] + 1;
                        }
                        else
                        {
                            dictionary.Add(item.ToString(), 1);
                        }
                    }

                }
            }
            return dictionary;

        }


        public Dictionary<String, int> ParallFlow(string strings)
        {


            ConcurrentDictionary<string, int> ConcDictionary = new ConcurrentDictionary<string, int>();


            var arrayStr = strings.Split('\n');


            Parallel.ForEach(arrayStr, str =>
            {
                Regex regex = new Regex(@"[A-zА-я]*");
                var regexStr = regex.Matches(str);

                foreach (var item in regexStr)
                {
                    if (item.ToString() != "")
                    {
                        ConcDictionary.AddOrUpdate(item.ToString(), 1, (k, v) => v + 1);
                    }

                }

            });

            Dictionary<string, int> dictionary = new Dictionary<string, int>(ConcDictionary);

            return dictionary;

        }


        public ConcurrentDictionary<String, int> ParallFlow(List<String> arrayStr)
        {

            // Создание потокобезопасного словаря 
            ConcurrentDictionary<string, int> ConcDictionary = new ConcurrentDictionary<string, int>();

           
            // Параллельная обработка коллекции строк 
            Parallel.ForEach(arrayStr, str =>
            {
                Regex regex = new Regex(@"[A-zА-я]*");
                var regexStr = regex.Matches(str);

                foreach (var item in regexStr)
                {
                    if (item.ToString() != "")
                    {
                        // добавление или изменение значений в словаре
                        ConcDictionary.AddOrUpdate(item.ToString(), 1,(k,v)=>v+1);
                    }

                }

            });

            return ConcDictionary;

        }     


        





    }
}
