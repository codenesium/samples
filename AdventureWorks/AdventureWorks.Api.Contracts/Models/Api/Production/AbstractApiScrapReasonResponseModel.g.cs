using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiScrapReasonResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        short scrapReasonID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ScrapReasonID = scrapReasonID;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public short ScrapReasonID { get; private set; }

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
                public bool ShouldSerializeScrapReasonIDValue { get; set; } = true;

                public bool ShouldSerializeScrapReasonID()
                {
                        return this.ShouldSerializeScrapReasonIDValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeScrapReasonIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>da1b7659b7ac86646e52102beb70d074</Hash>
</Codenesium>*/