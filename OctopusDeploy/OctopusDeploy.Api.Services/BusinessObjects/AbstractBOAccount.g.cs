using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOAccount : AbstractBusinessObject
	{
		public AbstractBOAccount()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  string accountType,
		                                  string environmentIds,
		                                  string jSON,
		                                  string name,
		                                  string tenantIds,
		                                  string tenantTags)
		{
			this.AccountType = accountType;
			this.EnvironmentIds = environmentIds;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
			this.TenantIds = tenantIds;
			this.TenantTags = tenantTags;
		}

		public string AccountType { get; private set; }

		public string EnvironmentIds { get; private set; }

		public string Id { get; private set; }

		public string JSON { get; private set; }

		public string Name { get; private set; }

		public string TenantIds { get; private set; }

		public string TenantTags { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b97897b5b51c2b73e63bc78008e810db</Hash>
</Codenesium>*/