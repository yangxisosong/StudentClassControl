﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentClassControl.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DoWork", ReplyAction="http://tempuri.org/IService1/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DoWork", ReplyAction="http://tempuri.org/IService1/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSalesVolume", ReplyAction="http://tempuri.org/IService1/GetSalesVolumeResponse")]
        System.Data.DataTable GetSalesVolume();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSalesVolume", ReplyAction="http://tempuri.org/IService1/GetSalesVolumeResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetSalesVolumeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Test", ReplyAction="http://tempuri.org/IService1/TestResponse")]
        int Test(int p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Test", ReplyAction="http://tempuri.org/IService1/TestResponse")]
        System.Threading.Tasks.Task<int> TestAsync(int p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Mycase", ReplyAction="http://tempuri.org/IService1/MycaseResponse")]
        string Mycase();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Mycase", ReplyAction="http://tempuri.org/IService1/MycaseResponse")]
        System.Threading.Tasks.Task<string> MycaseAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Loadding", ReplyAction="http://tempuri.org/IService1/LoaddingResponse")]
        int Loadding(string id, string passward);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Loadding", ReplyAction="http://tempuri.org/IService1/LoaddingResponse")]
        System.Threading.Tasks.Task<int> LoaddingAsync(string id, string passward);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Changepassward", ReplyAction="http://tempuri.org/IService1/ChangepasswardResponse")]
        int Changepassward(string pass, string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Changepassward", ReplyAction="http://tempuri.org/IService1/ChangepasswardResponse")]
        System.Threading.Tasks.Task<int> ChangepasswardAsync(string pass, string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Selectin", ReplyAction="http://tempuri.org/IService1/SelectinResponse")]
        System.Data.DataSet Selectin(string id, string table);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Selectin", ReplyAction="http://tempuri.org/IService1/SelectinResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> SelectinAsync(string id, string table);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Selectschool", ReplyAction="http://tempuri.org/IService1/SelectschoolResponse")]
        System.Data.DataSet Selectschool(string table);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Selectschool", ReplyAction="http://tempuri.org/IService1/SelectschoolResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> SelectschoolAsync(string table);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Insert", ReplyAction="http://tempuri.org/IService1/InsertResponse")]
        int Insert(string table, string id, string name, string sex, string stuclass, string discipline, string college, string intime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Insert", ReplyAction="http://tempuri.org/IService1/InsertResponse")]
        System.Threading.Tasks.Task<int> InsertAsync(string table, string id, string name, string sex, string stuclass, string discipline, string college, string intime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Myinsert", ReplyAction="http://tempuri.org/IService1/MyinsertResponse")]
        int Myinsert(string ins);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Myinsert", ReplyAction="http://tempuri.org/IService1/MyinsertResponse")]
        System.Threading.Tasks.Task<int> MyinsertAsync(string ins);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Selectout", ReplyAction="http://tempuri.org/IService1/SelectoutResponse")]
        System.Data.DataSet Selectout(string sqlout, string table);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Selectout", ReplyAction="http://tempuri.org/IService1/SelectoutResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> SelectoutAsync(string sqlout, string table);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : StudentClassControl.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<StudentClassControl.ServiceReference1.IService1>, StudentClassControl.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public System.Data.DataTable GetSalesVolume() {
            return base.Channel.GetSalesVolume();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetSalesVolumeAsync() {
            return base.Channel.GetSalesVolumeAsync();
        }
        
        public int Test(int p) {
            return base.Channel.Test(p);
        }
        
        public System.Threading.Tasks.Task<int> TestAsync(int p) {
            return base.Channel.TestAsync(p);
        }
        
        public string Mycase() {
            return base.Channel.Mycase();
        }
        
        public System.Threading.Tasks.Task<string> MycaseAsync() {
            return base.Channel.MycaseAsync();
        }
        
        public int Loadding(string id, string passward) {
            return base.Channel.Loadding(id, passward);
        }
        
        public System.Threading.Tasks.Task<int> LoaddingAsync(string id, string passward) {
            return base.Channel.LoaddingAsync(id, passward);
        }
        
        public int Changepassward(string pass, string id) {
            return base.Channel.Changepassward(pass, id);
        }
        
        public System.Threading.Tasks.Task<int> ChangepasswardAsync(string pass, string id) {
            return base.Channel.ChangepasswardAsync(pass, id);
        }
        
        public System.Data.DataSet Selectin(string id, string table) {
            return base.Channel.Selectin(id, table);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SelectinAsync(string id, string table) {
            return base.Channel.SelectinAsync(id, table);
        }
        
        public System.Data.DataSet Selectschool(string table) {
            return base.Channel.Selectschool(table);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SelectschoolAsync(string table) {
            return base.Channel.SelectschoolAsync(table);
        }
        
        public int Insert(string table, string id, string name, string sex, string stuclass, string discipline, string college, string intime) {
            return base.Channel.Insert(table, id, name, sex, stuclass, discipline, college, intime);
        }
        
        public System.Threading.Tasks.Task<int> InsertAsync(string table, string id, string name, string sex, string stuclass, string discipline, string college, string intime) {
            return base.Channel.InsertAsync(table, id, name, sex, stuclass, discipline, college, intime);
        }
        
        public int Myinsert(string ins) {
            return base.Channel.Myinsert(ins);
        }
        
        public System.Threading.Tasks.Task<int> MyinsertAsync(string ins) {
            return base.Channel.MyinsertAsync(ins);
        }
        
        public System.Data.DataSet Selectout(string sqlout, string table) {
            return base.Channel.Selectout(sqlout, table);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> SelectoutAsync(string sqlout, string table) {
            return base.Channel.SelectoutAsync(sqlout, table);
        }
    }
}
