using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiBillOfMaterialResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int billOfMaterialsID,
                        short bOMLevel,
                        int componentID,
                        DateTime? endDate,
                        DateTime modifiedDate,
                        double perAssemblyQty,
                        int? productAssemblyID,
                        DateTime startDate,
                        string unitMeasureCode)
                {
                        this.BillOfMaterialsID = billOfMaterialsID;
                        this.BOMLevel = bOMLevel;
                        this.ComponentID = componentID;
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.PerAssemblyQty = perAssemblyQty;
                        this.ProductAssemblyID = productAssemblyID;
                        this.StartDate = startDate;
                        this.UnitMeasureCode = unitMeasureCode;
                }

                [JsonProperty]
                public int BillOfMaterialsID { get; private set; }

                [JsonProperty]
                public short BOMLevel { get; private set; }

                [JsonProperty]
                public int ComponentID { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime? EndDate { get; private set; }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public double PerAssemblyQty { get; private set; }

                [Required]
                [JsonProperty]
                public int? ProductAssemblyID { get; private set; }

                [JsonProperty]
                public DateTime StartDate { get; private set; }

                [JsonProperty]
                public string UnitMeasureCode { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2eadf9a05ef1fb5b21ee03281d679b60</Hash>
</Codenesium>*/