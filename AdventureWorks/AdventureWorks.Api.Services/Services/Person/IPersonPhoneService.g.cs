using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>d4ce81205596f4679192c62dd5484fb4</Hash>
</Codenesium>*/