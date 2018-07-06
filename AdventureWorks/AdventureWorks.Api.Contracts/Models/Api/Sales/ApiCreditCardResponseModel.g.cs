using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiCreditCardResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int creditCardID,
                        string cardNumber,
                        string cardType,
                        int expMonth,
                        short expYear,
                        DateTime modifiedDate)
                {
                        this.CreditCardID = creditCardID;
                        this.CardNumber = cardNumber;
                        this.CardType = cardType;
                        this.ExpMonth = expMonth;
                        this.ExpYear = expYear;
                        this.ModifiedDate = modifiedDate;
                }

                public string CardNumber { get; private set; }

                public string CardType { get; private set; }

                public int CreditCardID { get; private set; }

                public int ExpMonth { get; private set; }

                public short ExpYear { get; private set; }

                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a7f34da8dddf4bebd78ad1ffb2fc7dc2</Hash>
</Codenesium>*/