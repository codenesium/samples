using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>513c3de3191bec1b8b6c96ec6729237b</Hash>
</Codenesium>*/