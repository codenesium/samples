using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public interface IBOLStateMapper
        {
                BOState MapModelToBO(
                        int id,
                        ApiStateRequestModel model);

                ApiStateResponseModel MapBOToModel(
                        BOState boState);

                List<ApiStateResponseModel> MapBOToModel(
                        List<BOState> items);
        }
}

/*<Codenesium>
    <Hash>dd890815e2b8c94cbc259d2d5c5b9293</Hash>
</Codenesium>*/