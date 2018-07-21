using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiPostTypesRequestModel : AbstractApiRequestModel
        {
                public ApiPostTypesRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string type)
                {
                        this.Type = type;
                }

                [JsonProperty]
                public string Type { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7f9a92338037e92282d74a66b4dcd60f</Hash>
</Codenesium>*/