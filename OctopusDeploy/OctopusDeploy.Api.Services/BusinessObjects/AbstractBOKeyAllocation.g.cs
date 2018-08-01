using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOKeyAllocation : AbstractBusinessObject
	{
		public AbstractBOKeyAllocation()
			: base()
		{
		}

		public virtual void SetProperties(string collectionName,
		                                  int allocated)
		{
			this.Allocated = allocated;
			this.CollectionName = collectionName;
		}

		public int Allocated { get; private set; }

		public string CollectionName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d5ea8a7b842a273eeb36b935a3094cf1</Hash>
</Codenesium>*/