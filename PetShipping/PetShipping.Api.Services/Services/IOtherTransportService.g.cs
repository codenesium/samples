using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IOtherTransportService
        {
                Task<CreateResponse<ApiOtherTransportResponseModel>> Create(
                        ApiOtherTransportRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiOtherTransportRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiOtherTransportResponseModel> Get(int id);

                Task<List<ApiOtherTransportResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c1ebfe9410ae8274ac6bcc9dee5d9117</Hash>
</Codenesium>*/