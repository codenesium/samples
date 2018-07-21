using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductModelResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productModelID,
                        string catalogDescription,
                        string instruction,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid)
                {
                        this.ProductModelID = productModelID;
                        this.CatalogDescription = catalogDescription;
                        this.Instruction = instruction;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                }

                [Required]
                [JsonProperty]
                public string CatalogDescription { get; private set; }

                [Required]
                [JsonProperty]
                public string Instruction { get; private set; }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public int ProductModelID { get; private set; }

                [JsonProperty]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>35210c8fef0fadc038c5e25614add940</Hash>
</Codenesium>*/