using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IAirlineService
        {
                Task<CreateResponse<ApiAirlineResponseModel>> Create(
                        ApiAirlineRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiAirlineRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiAirlineResponseModel> Get(int id);

                Task<List<ApiAirlineResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>a1d042243e835c71b7f85cb0372c36cb</Hash>
</Codenesium>*/