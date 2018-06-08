using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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
    <Hash>c46595d0b970c3c2c19dcc1b5079e782</Hash>
</Codenesium>*/