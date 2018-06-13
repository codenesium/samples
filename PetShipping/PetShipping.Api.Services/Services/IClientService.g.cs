using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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

                Task<List<ApiClientResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiClientCommunicationResponseModel>> ClientCommunications(int clientId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiPetResponseModel>> Pets(int clientId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiSaleResponseModel>> Sales(int clientId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>a16ffbb8def520dd1bd00dbba5d1ba5b</Hash>
</Codenesium>*/