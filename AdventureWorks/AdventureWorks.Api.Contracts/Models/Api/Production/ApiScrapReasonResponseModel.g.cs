using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public class ApiScrapReasonResponseModel : AbstractApiResponseModel
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
    <Hash>3290827ec39dd300563a570fb625894f</Hash>
</Codenesium>*/