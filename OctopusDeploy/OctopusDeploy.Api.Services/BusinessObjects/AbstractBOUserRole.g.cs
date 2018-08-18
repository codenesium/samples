using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOUserRole : AbstractBusinessObject
	{
		public AbstractBOUserRole()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  string jSON,
		                                  string name)
		{
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
		}

		public string Id { get; private set; }

		public string JSON { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b56a66360984b6b28e7ab96086957248</Hash>
</Codenesium>*/