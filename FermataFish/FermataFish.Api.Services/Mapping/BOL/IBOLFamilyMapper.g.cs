using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public interface IBOLFamilyMapper
        {
                BOFamily MapModelToBO(
                        int id,
                        ApiFamilyRequestModel model);

                ApiFamilyResponseModel MapBOToModel(
                        BOFamily boFamily);

                List<ApiFamilyResponseModel> MapBOToModel(
                        List<BOFamily> items);
        }
}

/*<Codenesium>
    <Hash>08277232e8bac81ce1cb3a3d90d97295</Hash>
</Codenesium>*/