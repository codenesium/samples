using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOMachinePolicy : AbstractBusinessObject
	{
		public AbstractBOMachinePolicy()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  bool isDefault,
		                                  string jSON,
		                                  string name)
		{
			this.Id = id;
			this.IsDefault = isDefault;
			this.JSON = jSON;
			this.Name = name;
		}

		public string Id { get; private set; }

		public bool IsDefault { get; private set; }

		public string JSON { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>52d6677c563fe57e4bdb002c0034b918</Hash>
</Codenesium>*/