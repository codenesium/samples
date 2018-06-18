using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOKeyAllocation: AbstractBusinessObject
        {
                public AbstractBOKeyAllocation() : base()
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
    <Hash>b36b40982836c21cf6e4543e1c156b49</Hash>
</Codenesium>*/