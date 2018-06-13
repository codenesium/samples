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

                Task<List<ApiClientCommunicationResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>e3d449f66ab9b56743ddcbd30e679780</Hash>
</Codenesium>*/