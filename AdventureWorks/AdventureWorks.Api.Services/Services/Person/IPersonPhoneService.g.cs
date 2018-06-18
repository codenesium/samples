using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IPersonPhoneService
        {
                Task<CreateResponse<ApiPersonPhoneResponseModel>> Create(
                        ApiPersonPhoneRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiPersonPhoneRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiPersonPhoneResponseModel> Get(int businessEntityID);

                Task<List<ApiPersonPhoneResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPersonPhoneResponseModel>> ByPhoneNumber(string phoneNumber);
        }
}

/*<Codenesium>
    <Hash>04fc522a308f14b53cc543af9aaae273</Hash>
</Codenesium>*/