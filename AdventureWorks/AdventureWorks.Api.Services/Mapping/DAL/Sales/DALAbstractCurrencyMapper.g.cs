using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractCurrencyMapper
        {
                public virtual Currency MapBOToEF(
                        BOCurrency bo)
                {
                        Currency efCurrency = new Currency();

                        efCurrency.SetProperties(
                                bo.CurrencyCode,
                                bo.ModifiedDate,
                                bo.Name);
                        return efCurrency;
                }

                public virtual BOCurrency MapEFToBO(
                        Currency ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOCurrency();

                        bo.SetProperties(
                                ef.CurrencyCode,
                                ef.ModifiedDate,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOCurrency> MapEFToBO(
                        List<Currency> records)
                {
                        List<BOCurrency> response = new List<BOCurrency>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b271a1b24e609ed98a570d21101c6255</Hash>
</Codenesium>*/