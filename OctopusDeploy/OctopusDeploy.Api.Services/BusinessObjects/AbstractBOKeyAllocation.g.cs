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
    <Hash>0057fa0df2f52bf46c73582686d4ecab</Hash>
</Codenesium>*/