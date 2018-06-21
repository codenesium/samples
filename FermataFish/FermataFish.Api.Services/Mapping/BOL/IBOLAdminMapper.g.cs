using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public interface IBOLAdminMapper
        {
                BOAdmin MapModelToBO(
                        int id,
                        ApiAdminRequestModel model);

                ApiAdminResponseModel MapBOToModel(
                        BOAdmin boAdmin);

                List<ApiAdminResponseModel> MapBOToModel(
                        List<BOAdmin> items);
        }
}

/*<Codenesium>
    <Hash>9c7319ada78fa7ac9d97a7b1f377d96f</Hash>
</Codenesium>*/