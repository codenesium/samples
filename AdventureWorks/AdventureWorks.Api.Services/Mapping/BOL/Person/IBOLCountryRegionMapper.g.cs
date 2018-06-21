using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLCountryRegionMapper
        {
                BOCountryRegion MapModelToBO(
                        string countryRegionCode,
                        ApiCountryRegionRequestModel model);

                ApiCountryRegionResponseModel MapBOToModel(
                        BOCountryRegion boCountryRegion);

                List<ApiCountryRegionResponseModel> MapBOToModel(
                        List<BOCountryRegion> items);
        }
}

/*<Codenesium>
    <Hash>3bcb6ec60d38ae644aa3bda184bbcb26</Hash>
</Codenesium>*/