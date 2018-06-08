using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IBOLCountryRequirementMapper
        {
                BOCountryRequirement MapModelToBO(
                        int id,
                        ApiCountryRequirementRequestModel model);

                ApiCountryRequirementResponseModel MapBOToModel(
                        BOCountryRequirement boCountryRequirement);

                List<ApiCountryRequirementResponseModel> MapBOToModel(
                        List<BOCountryRequirement> items);
        }
}

/*<Codenesium>
    <Hash>f122845f8153c335cdfceffbb3659204</Hash>
</Codenesium>*/