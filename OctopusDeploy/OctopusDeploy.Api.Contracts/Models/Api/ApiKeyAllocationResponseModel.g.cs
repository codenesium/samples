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
                        int allocated,
                        string collectionName)
                {
                        this.Allocated = allocated;
                        this.CollectionName = collectionName;
                }

                public int Allocated { get; private set; }

                public string CollectionName { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAllocatedValue { get; set; } = true;

                public bool ShouldSerializeAllocated()
                {
                        return this.ShouldSerializeAllocatedValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCollectionNameValue { get; set; } = true;

                public bool ShouldSerializeCollectionName()
                {
                        return this.ShouldSerializeCollectionNameValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAllocatedValue = false;
                        this.ShouldSerializeCollectionNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>2f914ea8f4b5ad286b7dc568f53e2bfc</Hash>
</Codenesium>*/