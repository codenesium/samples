using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiPersonCreditCardResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int businessEntityID,
                        int creditCardID,
                        DateTime modifiedDate)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.CreditCardID = creditCardID;
                        this.ModifiedDate = modifiedDate;

                        this.CreditCardIDEntity = nameof(ApiResponse.CreditCards);
                }

                public int BusinessEntityID { get; private set; }

                public int CreditCardID { get; private set; }

                public string CreditCardIDEntity { get; set; }

                public DateTime ModifiedDate { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

                public bool ShouldSerializeBusinessEntityID()
                {
                        return this.ShouldSerializeBusinessEntityIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeCreditCardIDValue { get; set; } = true;

                public bool ShouldSerializeCreditCardID()
                {
                        return this.ShouldSerializeCreditCardIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeBusinessEntityIDValue = false;
                        this.ShouldSerializeCreditCardIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>c080d5477f220c627c1f93d8d78677fd</Hash>
</Codenesium>*/