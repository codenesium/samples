using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractCountryRegionCurrencyMapper
        {
                public virtual CountryRegionCurrency MapBOToEF(
                        BOCountryRegionCurrency bo)
                {
                        CountryRegionCurrency efCountryRegionCurrency = new CountryRegionCurrency();

                        efCountryRegionCurrency.SetProperties(
                                bo.CountryRegionCode,
                                bo.CurrencyCode,
                                bo.ModifiedDate);
                        return efCountryRegionCurrency;
                }

                public virtual BOCountryRegionCurrency MapEFToBO(
                        CountryRegionCurrency ef)
                {
                        var bo = new BOCountryRegionCurrency();

                        bo.SetProperties(
                                ef.CountryRegionCode,
                                ef.CurrencyCode,
                                ef.ModifiedDate);
                        return bo;
                }

                public virtual List<BOCountryRegionCurrency> MapEFToBO(
                        List<CountryRegionCurrency> records)
                {
                        List<BOCountryRegionCurrency> response = new List<BOCountryRegionCurrency>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>bf08d0e577ca5d9328a1b0c003f2f7d4</Hash>
</Codenesium>*/