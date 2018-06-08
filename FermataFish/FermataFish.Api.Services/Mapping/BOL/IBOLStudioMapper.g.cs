using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IBOLStudioMapper
        {
                BOStudio MapModelToBO(
                        int id,
                        ApiStudioRequestModel model);

                ApiStudioResponseModel MapBOToModel(
                        BOStudio boStudio);

                List<ApiStudioResponseModel> MapBOToModel(
                        List<BOStudio> items);
        }
}

/*<Codenesium>
    <Hash>b4ae427b5d457ed7f4eb4f5d315e469d</Hash>
</Codenesium>*/