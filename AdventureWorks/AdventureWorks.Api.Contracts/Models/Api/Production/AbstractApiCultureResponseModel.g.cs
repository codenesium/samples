using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiCultureResponseModel: AbstractApiResponseModel
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
    <Hash>81ca3d67d9f96c243f7a9070efc199d4</Hash>
</Codenesium>*/