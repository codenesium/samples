using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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
    <Hash>d2df00ca72024864dacba3e9891500b2</Hash>
</Codenesium>*/