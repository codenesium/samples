using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOWorkerPool : AbstractBusinessObject
	{
		public AbstractBOWorkerPool()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  bool isDefault,
		                                  string jSON,
		                                  string name,
		                                  int sortOrder)
		{
			this.Id = id;
			this.IsDefault = isDefault;
			this.JSON = jSON;
			this.Name = name;
			this.SortOrder = sortOrder;
		}

		public string Id { get; private set; }

		public bool IsDefault { get; private set; }

		public string JSON { get; private set; }

		public string Name { get; private set; }

		public int SortOrder { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c029ca6e31c5ff5727931d07954648d1</Hash>
</Codenesium>*/