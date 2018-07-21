using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesTerritoryHistoryRequestModel : AbstractApiRequestModel
        {
                public ApiSalesTerritoryHistoryRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime? endDate,
                        DateTime modifiedDate,
                        Guid rowguid,
                        DateTime startDate,
                        int territoryID)
                {
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                        this.StartDate = startDate;
                        this.TerritoryID = territoryID;
                }

                [JsonProperty]
                public DateTime? EndDate { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public Guid Rowguid { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime StartDate { get; private set; }

                [Required]
                [JsonProperty]
                public int TerritoryID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>46b5b722fd66b9f531583fd71580a5f6</Hash>
</Codenesium>*/