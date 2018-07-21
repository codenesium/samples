using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiPostHistoryTypesRequestModel : AbstractApiRequestModel
        {
                public ApiPostHistoryTypesRequestModel()
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
    <Hash>b5a9d37ef38c55388a2ad363984ba567</Hash>
</Codenesium>*/