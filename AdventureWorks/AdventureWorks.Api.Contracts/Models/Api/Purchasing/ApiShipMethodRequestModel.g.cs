using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiShipMethodRequestModel : AbstractApiRequestModel
        {
                public ApiShipMethodRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid,
                        decimal shipBase,
                        decimal shipRate)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.ShipBase = shipBase;
                        this.ShipRate = shipRate;
                }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [Required]
                [JsonProperty]
                public Guid Rowguid { get; private set; }

                [Required]
                [JsonProperty]
                public decimal ShipBase { get; private set; }

                [Required]
                [JsonProperty]
                public decimal ShipRate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e387367d5bf2ac22e94eb039635333b4</Hash>
</Codenesium>*/