﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.

    [ServiceContract]
    public interface IService1
    {
        // [OperationContract]
        //  Dictionary<String, int> OneFlowProcessingStr(string strings);
        [OperationContract]
        Dictionary<String, int> ParallProcessing();


        [OperationContract]
        Dictionary<String, int> ParallProcessingStr(string stringsText);


        [OperationContract]
        void addStr(string str);




        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Добавьте здесь операции служб
    }
        
    

}
