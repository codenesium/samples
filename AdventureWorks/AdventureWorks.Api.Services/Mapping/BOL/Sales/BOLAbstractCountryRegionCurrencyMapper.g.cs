using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractCountryRegionCurrencyMapper
        {
                public virtual BOCountryRegionCurrency MapModelToBO(
                        string countryRegionCode,
                        ApiCountryRegionCurrencyRequestModel model
                        )
                {
                        BOCountryRegionCurrency boCountryRegionCurrency = new BOCountryRegionCurrency();

                        boCountryRegionCurrency.SetProperties(
                                countryRegionCode,
                                model.CurrencyCode,
                                model.ModifiedDate);
                        return boCountryRegionCurrency;
                }

                public virtual ApiCountryRegionCurrencyResponseModel MapBOToModel(
                        BOCountryRegionCurrency boCountryRegionCurrency)
                {
                        var model = new ApiCountryRegionCurrencyResponseModel();

                        model.SetProperties(boCountryRegionCurrency.CountryRegionCode, boCountryRegionCurrency.CurrencyCode, boCountryRegionCurrency.ModifiedDate);

                        return model;
                }

                public virtual List<ApiCountryRegionCurrencyResponseModel> MapBOToModel(
                        List<BOCountryRegionCurrency> items)
                {
                        List<ApiCountryRegionCurrencyResponseModel> response = new List<ApiCountryRegionCurrencyResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>2d95e37aacbb5963ca27c3770d15cb84</Hash>
</Codenesium>*/