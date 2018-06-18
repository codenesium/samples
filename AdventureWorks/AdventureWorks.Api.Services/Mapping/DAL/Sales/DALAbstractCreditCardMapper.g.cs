using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractCreditCardMapper
        {
                public virtual CreditCard MapBOToEF(
                        BOCreditCard bo)
                {
                        CreditCard efCreditCard = new CreditCard();

                        efCreditCard.SetProperties(
                                bo.CardNumber,
                                bo.CardType,
                                bo.CreditCardID,
                                bo.ExpMonth,
                                bo.ExpYear,
                                bo.ModifiedDate);
                        return efCreditCard;
                }

                public virtual BOCreditCard MapEFToBO(
                        CreditCard ef)
                {
                        var bo = new BOCreditCard();

                        bo.SetProperties(
                                ef.CreditCardID,
                                ef.CardNumber,
                                ef.CardType,
                                ef.ExpMonth,
                                ef.ExpYear,
                                ef.ModifiedDate);
                        return bo;
                }

                public virtual List<BOCreditCard> MapEFToBO(
                        List<CreditCard> records)
                {
                        List<BOCreditCard> response = new List<BOCreditCard>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>76d0469d468270b824ad4ed424076c83</Hash>
</Codenesium>*/