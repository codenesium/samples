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

                public void SetProperties(
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
    <Hash>e2475a3f634f6795c60537b7fc542dc1</Hash>
</Codenesium>*/