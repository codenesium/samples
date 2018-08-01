using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOTenant : AbstractBusinessObject
	{
		public AbstractBOTenant()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  byte[] dataVersion,
		                                  string jSON,
		                                  string name,
		                                  string projectIds,
		                                  string tenantTags)
		{
			this.DataVersion = dataVersion;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
			this.ProjectIds = projectIds;
			this.TenantTags = tenantTags;
		}

		public byte[] DataVersion { get; private set; }

		public string Id { get; private set; }

		public string JSON { get; private set; }

		public string Name { get; private set; }

		public string ProjectIds { get; private set; }

		public string TenantTags { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d664a3a5d06f1d6c41dc9a5354e7f70c</Hash>
</Codenesium>*/