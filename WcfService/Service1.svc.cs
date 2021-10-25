using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using System.Collections.Concurrent;
using System.IO;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {


        // Reflection

        //public Dictionary<String, int> OneFlowProcessingStr(string strings)
        //{

        //    ConcurrentDictionary<int, int> a = new ConcurrentDictionary<int, int>();

        //    Dictionary<String, int> dictionary = new Dictionary<string, int>();

        //    Assembly asm = Assembly.LoadFrom("WordsProcessing.dll");
        //    var types = asm.GetTypes();
        //    var t = types.FirstOrDefault(u => u.Name == "FlowsProcessing");
        //    var c = (WordProcessing.FlowsProcessing)Activator.CreateInstance(t);
        //    var mi = c.GetType().GetMethod("OneFlow", System.Reflection.BindingFlags.NonPublic | BindingFlags.Instance);

        //    var OneFlowMetod = mi.Invoke(c, new object[] { strings });

        //    dictionary = (Dictionary<string, int>)OneFlowMetod;

        //    return dictionary;
        //}


        public static StringBuilder stringsBilderText = new StringBuilder();

        public void addStr(string strs)
        {
            stringsBilderText.Append(strs);
        }


        public Dictionary<String, int> ParallProcessing()
        {

            var flowsProcessing = new WordProcessing.FlowsProcessing();

            Dictionary<String, int> dictionary = flowsProcessing.ParallFlow(stringsBilderText.ToString());

            return dictionary;
        }



        public Dictionary<String, int> ParallProcessingStr(string stringsText)
        {

            var flowsProcessing = new WordProcessing.FlowsProcessing();

            Dictionary<String, int> dictionary = flowsProcessing.ParallFlow(stringsText.ToString());

            return dictionary;
        }



        public string GetData(int value)
        {
            return string.Format("You entered:1 {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
