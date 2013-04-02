//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace ODataRelay
{

    //TRAVIS: added attribute to see stack trace
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class MyNorthwindService : DataService<PublicNorthwind.NorthwindEntities>, IUpdatable
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            // config.SetServiceOperationAccessRule("MyServiceOperation", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
        }

        protected override void OnStartProcessingRequest(ProcessRequestArgs args)
        {
            var x = args.OperationContext.RequestHeaders["X-CSRF-Token"];
            base.OnStartProcessingRequest(args);
        }

        public void AddReferenceToCollection(object targetResource, string propertyName, object resourceToBeAdded)
        {
            throw new NotImplementedException();
        }

        public void ClearChanges()
        {
            throw new NotImplementedException();
        }

        public object CreateResource(string containerName, string fullTypeName)
        {
            Type t = Type.GetType(fullTypeName, true);
            object entity = Activator.CreateInstance(t);
            this.CurrentDataSource.AddObject(containerName, entity);
            return entity;
        }

        public void DeleteResource(object targetResource)
        {
            throw new NotImplementedException();
        }

        public object GetResource(IQueryable query, string fullTypeName)
        {
            throw new NotImplementedException();
        }

        public object GetValue(object targetResource, string propertyName)
        {
            throw new NotImplementedException();
        }

        public void RemoveReferenceFromCollection(object targetResource, string propertyName, object resourceToBeRemoved)
        {
            throw new NotImplementedException();
        }

        public object ResetResource(object resource)
        {
            throw new NotImplementedException();
        }

        public object ResolveResource(object resource)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            base.CurrentDataSource.SaveChanges();
        }

        public void SetReference(object targetResource, string propertyName, object propertyValue)
        {
            throw new NotImplementedException();
        }

        public void SetValue(object targetResource, string propertyName, object propertyValue)
        {
            throw new NotImplementedException();
        }
    }
}
