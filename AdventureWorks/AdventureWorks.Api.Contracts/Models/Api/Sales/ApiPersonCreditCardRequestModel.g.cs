using Codenesium.DataConversionExtensions;
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
    <Hash>13789e75492043ba73565812232f71c9</Hash>
</Codenesium>*/