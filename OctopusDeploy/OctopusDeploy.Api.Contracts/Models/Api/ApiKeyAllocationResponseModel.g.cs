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
    <Hash>ad5c0d2c08bd24d9168cd0da6f8416e7</Hash>
</Codenesium>*/