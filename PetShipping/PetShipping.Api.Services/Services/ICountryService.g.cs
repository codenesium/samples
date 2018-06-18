using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface ICountryService
        {
                Task<CreateResponse<ApiCountryResponseModel>> Create(
                        ApiCountryRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiCountryRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiCountryResponseModel> Get(int id);

                Task<List<ApiCountryResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiCountryRequirementResponseModel>> CountryRequirements(int countryId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiDestinationResponseModel>> Destinations(int countryId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>20d0040eae4b446a9fdd2eafa8b36a47</Hash>
</Codenesium>*/