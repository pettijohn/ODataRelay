using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Linq;
using System.Web;

namespace ODataRelay.PublicNorthwind
{
    /// <summary>
    /// There are no comments for NorthwindEntities in the schema.
    /// </summary>
    public partial class NorthwindEntities : global::System.Data.Services.Client.DataServiceContext, IUpdatable
    {
        public NorthwindEntities() : this(new Uri("http://services.odata.org/Northwind/Northwind.svc/"))
        {
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
            AddObject(containerName, entity);
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

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public void SetReference(object targetResource, string propertyName, object propertyValue)
        {
            throw new NotImplementedException();
        }

        public void SetValue(object targetResource, string propertyName, object propertyValue)
        {
            var t = targetResource.GetType();
            var prop = t.GetProperty(propertyName, System.Reflection.BindingFlags.FlattenHierarchy | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            prop.SetValue(targetResource, propertyValue);
        }
    }
}