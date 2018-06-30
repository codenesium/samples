using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>de16868ee30adb6074956a50eb421985</Hash>
</Codenesium>*/