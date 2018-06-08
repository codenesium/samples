using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>6b63ca6136a6b1979e660ebc8a6f8b16</Hash>
</Codenesium>*/