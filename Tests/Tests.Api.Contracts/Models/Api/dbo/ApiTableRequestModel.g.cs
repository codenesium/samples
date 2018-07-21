using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
        public partial class ApiTableRequestModel : AbstractApiRequestModel
        {
                public ApiTableRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string name)
                {
                        this.Name = name;
                }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b29021c53cc0c95dd7858f9a1c6fa85e</Hash>
</Codenesium>*/