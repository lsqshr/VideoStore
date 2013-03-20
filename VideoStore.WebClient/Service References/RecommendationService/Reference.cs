﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VideoStore.WebClient.RecommendationService {
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
    public class ObjectsAddedToCollectionProperties : System.Collections.Generic.Dictionary<string, VideoStore.WebClient.RecommendationService.ObjectList> {
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
    public class ObjectsRemovedFromCollectionProperties : System.Collections.Generic.Dictionary<string, VideoStore.WebClient.RecommendationService.ObjectList> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="OriginalValuesDictionary", Namespace="http://schemas.datacontract.org/2004/07/VideoStore.Business.Entities", ItemName="OriginalValues", KeyName="Name", ValueName="OriginalValue")]
    [System.SerializableAttribute()]
    public class OriginalValuesDictionary : System.Collections.Generic.Dictionary<string, object> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RecommendationService.IRecommendationService")]
    public interface IRecommendationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRecommendationService/UserLikeMedia", ReplyAction="http://tempuri.org/IRecommendationService/UserLikeMediaResponse")]
        void UserLikeMedia(int pUserId, int pMediaId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRecommendationService/GetRecommendationListByUserId", ReplyAction="http://tempuri.org/IRecommendationService/GetRecommendationListByUserIdResponse")]
        VideoStore.Business.Entities.Recommendation[] GetRecommendationListByUserId(int UserId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRecommendationServiceChannel : VideoStore.WebClient.RecommendationService.IRecommendationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RecommendationServiceClient : System.ServiceModel.ClientBase<VideoStore.WebClient.RecommendationService.IRecommendationService>, VideoStore.WebClient.RecommendationService.IRecommendationService {
        
        public RecommendationServiceClient() {
        }
        
        public RecommendationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RecommendationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RecommendationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RecommendationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void UserLikeMedia(int pUserId, int pMediaId) {
            base.Channel.UserLikeMedia(pUserId, pMediaId);
        }
        
        public VideoStore.Business.Entities.Recommendation[] GetRecommendationListByUserId(int UserId) {
            return base.Channel.GetRecommendationListByUserId(UserId);
        }
    }
}