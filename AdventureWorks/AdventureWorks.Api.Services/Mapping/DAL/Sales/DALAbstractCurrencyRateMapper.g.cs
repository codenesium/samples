using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractCurrencyRateMapper
        {
                public virtual CurrencyRate MapBOToEF(
                        BOCurrencyRate bo)
                {
                        CurrencyRate efCurrencyRate = new CurrencyRate();

                        efCurrencyRate.SetProperties(
                                bo.AverageRate,
                                bo.CurrencyRateDate,
                                bo.CurrencyRateID,
                                bo.EndOfDayRate,
                                bo.FromCurrencyCode,
                                bo.ModifiedDate,
                                bo.ToCurrencyCode);
                        return efCurrencyRate;
                }

                public virtual BOCurrencyRate MapEFToBO(
                        CurrencyRate ef)
                {
                        var bo = new BOCurrencyRate();

                        bo.SetProperties(
                                ef.CurrencyRateID,
                                ef.AverageRate,
                                ef.CurrencyRateDate,
                                ef.EndOfDayRate,
                                ef.FromCurrencyCode,
                                ef.ModifiedDate,
                                ef.ToCurrencyCode);
                        return bo;
                }

                public virtual List<BOCurrencyRate> MapEFToBO(
                        List<CurrencyRate> records)
                {
                        List<BOCurrencyRate> response = new List<BOCurrencyRate>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>b4dd6079922668793a7be9b14b1f5724</Hash>
</Codenesium>*/