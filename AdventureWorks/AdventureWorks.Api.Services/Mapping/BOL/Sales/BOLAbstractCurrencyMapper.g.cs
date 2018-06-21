using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractCurrencyMapper
        {
                public virtual BOCurrency MapModelToBO(
                        string currencyCode,
                        ApiCurrencyRequestModel model
                        )
                {
                        BOCurrency boCurrency = new BOCurrency();
                        boCurrency.SetProperties(
                                currencyCode,
                                model.ModifiedDate,
                                model.Name);
                        return boCurrency;
                }

                public virtual ApiCurrencyResponseModel MapBOToModel(
                        BOCurrency boCurrency)
                {
                        var model = new ApiCurrencyResponseModel();

                        model.SetProperties(boCurrency.CurrencyCode, boCurrency.ModifiedDate, boCurrency.Name);

                        return model;
                }

                public virtual List<ApiCurrencyResponseModel> MapBOToModel(
                        List<BOCurrency> items)
                {
                        List<ApiCurrencyResponseModel> response = new List<ApiCurrencyResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>5b5f507001d02b531b598ec22eccf51d</Hash>
</Codenesium>*/