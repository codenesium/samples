using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPersonCreditCardRequestModel: AbstractApiRequestModel
        {
                public ApiPersonCreditCardRequestModel() : base()
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
    <Hash>d1dcd17b6cf371b859eb03ebdde72472</Hash>
</Codenesium>*/