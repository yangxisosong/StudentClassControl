using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceyxs1
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        DataTable GetSalesVolume();

        [OperationContract]
        int Test(int p);

        [OperationContract]
        string Mycase();

        [OperationContract]
        int Loadding(string id, string passward);

        [OperationContract]
        int Changepassward(string pass, string id);

        [OperationContract]
        DataSet Selectin(string id, string table);

        [OperationContract]
        DataSet Selectschool(string table);

        [OperationContract]
        int Insert(string table, string id, string name, string sex, string stuclass, string discipline, string college, string intime);

        [OperationContract]
        int Myinsert(string ins);

        [OperationContract]
        DataSet Selectout(string sqlout, string table);
    }
}
