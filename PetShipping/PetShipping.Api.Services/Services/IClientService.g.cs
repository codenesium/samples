using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IClientService
        {
                Task<CreateResponse<ApiClientResponseModel>> Create(
                        ApiClientRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiClientRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiClientResponseModel> Get(int id);

                Task<List<ApiClientResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiClientCommunicationResponseModel>> ClientCommunications(int clientId, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPetResponseModel>> Pets(int clientId, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSaleResponseModel>> Sales(int clientId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>f5432766edc0e38d22f7cf6eda78e003</Hash>
</Codenesium>*/