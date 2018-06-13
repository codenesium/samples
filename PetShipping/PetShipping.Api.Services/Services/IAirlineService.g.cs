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

                Task<List<ApiAirlineResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>4f5a26d8e52fb1d9910099776ff23fbb</Hash>
</Codenesium>*/