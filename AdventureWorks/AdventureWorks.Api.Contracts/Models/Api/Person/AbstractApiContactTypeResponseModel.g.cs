using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiContactTypeResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int contactTypeID,
                        DateTime modifiedDate,
                        string name)
                {
                        this.ContactTypeID = contactTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                public int ContactTypeID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeContactTypeIDValue { get; set; } = true;

                public bool ShouldSerializeContactTypeID()
                {
                        return this.ShouldSerializeContactTypeIDValue;
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
                        this.ShouldSerializeContactTypeIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>82bbc016c3b2e43396870214ba66f17d</Hash>
</Codenesium>*/