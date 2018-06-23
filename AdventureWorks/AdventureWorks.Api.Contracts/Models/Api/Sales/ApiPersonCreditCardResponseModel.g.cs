using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public class ApiPersonCreditCardResponseModel : AbstractApiResponseModel
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
    <Hash>0fe4af1034f1341093df7b5130a3bcc3</Hash>
</Codenesium>*/