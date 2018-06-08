using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractCountryRegionMapper
        {
                public virtual BOCountryRegion MapModelToBO(
                        string countryRegionCode,
                        ApiCountryRegionRequestModel model
                        )
                {
                        BOCountryRegion boCountryRegion = new BOCountryRegion();

                        boCountryRegion.SetProperties(
                                countryRegionCode,
                                model.ModifiedDate,
                                model.Name);
                        return boCountryRegion;
                }

                public virtual ApiCountryRegionResponseModel MapBOToModel(
                        BOCountryRegion boCountryRegion)
                {
                        var model = new ApiCountryRegionResponseModel();

                        model.SetProperties(boCountryRegion.CountryRegionCode, boCountryRegion.ModifiedDate, boCountryRegion.Name);

                        return model;
                }

                public virtual List<ApiCountryRegionResponseModel> MapBOToModel(
                        List<BOCountryRegion> items)
                {
                        List<ApiCountryRegionResponseModel> response = new List<ApiCountryRegionResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>229c55458bb51c515e336723a5d42aae</Hash>
</Codenesium>*/