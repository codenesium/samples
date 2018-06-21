using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IClientCommunicationService
        {
                Task<CreateResponse<ApiClientCommunicationResponseModel>> Create(
                        ApiClientCommunicationRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiClientCommunicationRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiClientCommunicationResponseModel> Get(int id);

                Task<List<ApiClientCommunicationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>fcd3ddde95dddf331b0775e1ec341eb3</Hash>
</Codenesium>*/