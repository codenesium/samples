using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public interface IBOLRateMapper
        {
                BORate MapModelToBO(
                        int id,
                        ApiRateRequestModel model);

                ApiRateResponseModel MapBOToModel(
                        BORate boRate);

                List<ApiRateResponseModel> MapBOToModel(
                        List<BORate> items);
        }
}

/*<Codenesium>
    <Hash>2e8580809e4c32f9c37b9f36f2b6161d</Hash>
</Codenesium>*/