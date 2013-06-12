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

namespace MvcApp
{

    //TRAVIS: added attribute to see stack trace
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class MyNorthwindService : DataService<MvcApp.PublicODataDirect.NorthwindEntities>//, IUpdatable
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
            // Examples:
            config.SetEntitySetAccessRule("*", EntitySetRights.All);
            //config.SetServiceOperationAccessRule("Login", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V1;
        }

        //protected override void OnStartProcessingRequest(ProcessRequestArgs args)
        //{
        //    var x = args.OperationContext.RequestHeaders["X-CSRF-Token"];
        //    base.OnStartProcessingRequest(args);
        //}

        //[WebGet]
        //public LoginResult Login(string userID, string password)
        //{
        //    return new LoginResult();
        //}
    }
}
