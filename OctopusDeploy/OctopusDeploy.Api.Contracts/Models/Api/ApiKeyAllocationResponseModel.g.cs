using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiKeyAllocationResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string collectionName,
                        int allocated)
                {
                        this.CollectionName = collectionName;
                        this.Allocated = allocated;
                }

                public int Allocated { get; private set; }

                public string CollectionName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>d10819d455dd9e9c88f199687a543322</Hash>
</Codenesium>*/