using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiLinkTypesRequestModel : AbstractApiRequestModel
        {
                public ApiLinkTypesRequestModel()
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
    <Hash>138848f5d485318a0c5a8f5ee76ae882</Hash>
</Codenesium>*/