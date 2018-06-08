using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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
    <Hash>5fef527cc531c3c8cfa55d63547ff64d</Hash>
</Codenesium>*/