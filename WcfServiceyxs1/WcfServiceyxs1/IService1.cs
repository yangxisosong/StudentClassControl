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

        //登录密码判断
        [OperationContract]
        int Loadding(string id, string passward);
        //修改密码
        [OperationContract]
        int Changepassward(string pass, string id);
        //查询需要的表格
        [OperationContract]
        DataSet Selectin(string id, string table);
        //查询专业
        [OperationContract]
        DataSet Selectschool(string table);
        //插入数据
        [OperationContract]
        int Insert(string table, string id, string name, string sex, string stuclass, string discipline, string college, string intime);
        //插入多条数据
        [OperationContract]
        int Myinsert(string ins);
        //自定义查询表格
        [OperationContract]
        DataSet Selectout(string sqlout, string table);
    }
}
