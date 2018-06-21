using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiCultureResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string cultureID,
                        DateTime modifiedDate,
                        string name)
                {
                        this.CultureID = cultureID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                public string CultureID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeCultureIDValue { get; set; } = true;

                public bool ShouldSerializeCultureID()
                {
                        return this.ShouldSerializeCultureIDValue;
                }

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

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCultureIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>8c5c667c90ec532116ecde83300862d2</Hash>
</Codenesium>*/