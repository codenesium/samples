using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductModelRequestModel : AbstractApiRequestModel
        {
                public ApiProductModelRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string catalogDescription,
                        string instruction,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid)
                {
                        this.CatalogDescription = catalogDescription;
                        this.Instruction = instruction;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                }

                [JsonProperty]
                public string CatalogDescription { get; private set; }

                [JsonProperty]
                public string Instruction { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [Required]
                [JsonProperty]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>99064d2ecb2d862921a44ab0c296b134</Hash>
</Codenesium>*/