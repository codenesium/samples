using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOKeyAllocation: AbstractBusinessObject
        {
                public BOKeyAllocation() : base()
                {
                }

                public void SetProperties(string collectionName,
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
    <Hash>82a86bdadc84456804b0c2ca9a455ac9</Hash>
</Codenesium>*/