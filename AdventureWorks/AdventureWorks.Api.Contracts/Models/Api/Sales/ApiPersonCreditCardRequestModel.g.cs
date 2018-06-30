using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPersonCreditCardRequestModel : AbstractApiRequestModel
        {
                public ApiPersonCreditCardRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int creditCardID,
                        DateTime modifiedDate)
                {
                        this.CreditCardID = creditCardID;
                        this.ModifiedDate = modifiedDate;
                }

                private int creditCardID;

                [Required]
                public int CreditCardID
                {
                        get
                        {
                                return this.creditCardID;
                        }

                        set
                        {
                                this.creditCardID = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>c1d4d55a889a9b2aa14391091583fb22</Hash>
</Codenesium>*/