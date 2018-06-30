using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiScrapReasonResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        short scrapReasonID,
                        DateTime modifiedDate,
                        string name)
                {
                        this.ScrapReasonID = scrapReasonID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
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
    <Hash>3d0f8accd39200831d88e43370fab765</Hash>
</Codenesium>*/