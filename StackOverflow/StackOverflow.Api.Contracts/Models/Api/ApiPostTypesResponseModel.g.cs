using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiPostTypesResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string type)
                {
                        this.Id = id;
                        this.Type = type;
                }

                public int Id { get; private set; }

                public string Type { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTypeValue { get; set; } = true;

                public bool ShouldSerializeType()
                {
                        return this.ShouldSerializeTypeValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeTypeValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>7a711f5e93ae0182f1fb77b51f81835a</Hash>
</Codenesium>*/