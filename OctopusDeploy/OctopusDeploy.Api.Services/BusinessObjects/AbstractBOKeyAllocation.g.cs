using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>43e3a399f5b802893ce284e5ed593f68</Hash>
</Codenesium>*/