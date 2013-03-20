﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VideoStore.WebClient.UserService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ExtendedPropertiesDictionary", Namespace="http://schemas.datacontract.org/2004/07/VideoStore.Business.Entities", ItemName="ExtendedProperties", KeyName="Name", ValueName="ExtendedProperty")]
    [System.SerializableAttribute()]
    public class ExtendedPropertiesDictionary : System.Collections.Generic.Dictionary<string, object> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ObjectsAddedToCollectionProperties", Namespace="http://schemas.datacontract.org/2004/07/VideoStore.Business.Entities", ItemName="AddedObjectsForProperty", KeyName="CollectionPropertyName", ValueName="AddedObjects")]
    [System.SerializableAttribute()]
    public class ObjectsAddedToCollectionProperties : System.Collections.Generic.Dictionary<string, VideoStore.WebClient.UserService.ObjectList> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ObjectList", Namespace="http://schemas.datacontract.org/2004/07/VideoStore.Business.Entities", ItemName="ObjectValue")]
    [System.SerializableAttribute()]
    public class ObjectList : System.Collections.Generic.List<object> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ObjectsRemovedFromCollectionProperties", Namespace="http://schemas.datacontract.org/2004/07/VideoStore.Business.Entities", ItemName="DeletedObjectsForProperty", KeyName="CollectionPropertyName", ValueName="DeletedObjects")]
    [System.SerializableAttribute()]
    public class ObjectsRemovedFromCollectionProperties : System.Collections.Generic.Dictionary<string, VideoStore.WebClient.UserService.ObjectList> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="OriginalValuesDictionary", Namespace="http://schemas.datacontract.org/2004/07/VideoStore.Business.Entities", ItemName="OriginalValues", KeyName="Name", ValueName="OriginalValue")]
    [System.SerializableAttribute()]
    public class OriginalValuesDictionary : System.Collections.Generic.Dictionary<string, object> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserService.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/CreateUser", ReplyAction="http://tempuri.org/IUserService/CreateUserResponse")]
        void CreateUser(VideoStore.Business.Entities.User pUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/ReadUserById", ReplyAction="http://tempuri.org/IUserService/ReadUserByIdResponse")]
        VideoStore.Business.Entities.User ReadUserById(int pUserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/ReadUserByName", ReplyAction="http://tempuri.org/IUserService/ReadUserByNameResponse")]
        VideoStore.Business.Entities.User ReadUserByName(string pUserName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdateUser", ReplyAction="http://tempuri.org/IUserService/UpdateUserResponse")]
        void UpdateUser(VideoStore.Business.Entities.User pUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/DeleteUser", ReplyAction="http://tempuri.org/IUserService/DeleteUserResponse")]
        void DeleteUser(VideoStore.Business.Entities.User pUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/ValidateUserLoginCredentials", ReplyAction="http://tempuri.org/IUserService/ValidateUserLoginCredentialsResponse")]
        bool ValidateUserLoginCredentials(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserByUserNamePassword", ReplyAction="http://tempuri.org/IUserService/GetUserByUserNamePasswordResponse")]
        VideoStore.Business.Entities.User GetUserByUserNamePassword(string username, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : VideoStore.WebClient.UserService.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<VideoStore.WebClient.UserService.IUserService>, VideoStore.WebClient.UserService.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void CreateUser(VideoStore.Business.Entities.User pUser) {
            base.Channel.CreateUser(pUser);
        }
        
        public VideoStore.Business.Entities.User ReadUserById(int pUserId) {
            return base.Channel.ReadUserById(pUserId);
        }
        
        public VideoStore.Business.Entities.User ReadUserByName(string pUserName) {
            return base.Channel.ReadUserByName(pUserName);
        }
        
        public void UpdateUser(VideoStore.Business.Entities.User pUser) {
            base.Channel.UpdateUser(pUser);
        }
        
        public void DeleteUser(VideoStore.Business.Entities.User pUser) {
            base.Channel.DeleteUser(pUser);
        }
        
        public bool ValidateUserLoginCredentials(string username, string password) {
            return base.Channel.ValidateUserLoginCredentials(username, password);
        }
        
        public VideoStore.Business.Entities.User GetUserByUserNamePassword(string username, string password) {
            return base.Channel.GetUserByUserNamePassword(username, password);
        }
    }
}
