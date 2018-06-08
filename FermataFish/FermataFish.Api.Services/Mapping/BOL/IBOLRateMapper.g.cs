using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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
    <Hash>b0628f436b632c8477400d4c347c6641</Hash>
</Codenesium>*/