using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public class ApiUnitMeasureResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        string unitMeasureCode)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.UnitMeasureCode = unitMeasureCode;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public string UnitMeasureCode { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeUnitMeasureCodeValue { get; set; } = true;

                public bool ShouldSerializeUnitMeasureCode()
                {
                        return this.ShouldSerializeUnitMeasureCodeValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeUnitMeasureCodeValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>9208510be5859a37a050520889322e67</Hash>
</Codenesium>*/