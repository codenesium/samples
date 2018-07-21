using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TestsNS.Api.Contracts
{
        public partial class ApiRowVersionCheckRequestModel : AbstractApiRequestModel
        {
                public ApiRowVersionCheckRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string name,
                        Guid rowVersion)
                {
                        this.Name = name;
                        this.RowVersion = rowVersion;
                }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [Required]
                [JsonProperty]
                public Guid RowVersion { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a33a5fd9d2d4284dc26351c3d24cc819</Hash>
</Codenesium>*/