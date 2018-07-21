using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductDescriptionRequestModel : AbstractApiRequestModel
        {
                public ApiProductDescriptionRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string description,
                        DateTime modifiedDate,
                        Guid rowguid)
                {
                        this.Description = description;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                [Required]
                [JsonProperty]
                public string Description { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>3fcfde50775f00560cc31b71e76a025c</Hash>
</Codenesium>*/