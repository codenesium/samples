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
    <Hash>a4ebad494dee48b08fa35954f4789f08</Hash>
</Codenesium>*/