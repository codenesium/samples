using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiUnitMeasureResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string unitMeasureCode,
                        DateTime modifiedDate,
                        string name)
                {
                        this.UnitMeasureCode = unitMeasureCode;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }

                [JsonProperty]
                public string UnitMeasureCode { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9f4b6c05789b0f47a24b60e71c214ccd</Hash>
</Codenesium>*/