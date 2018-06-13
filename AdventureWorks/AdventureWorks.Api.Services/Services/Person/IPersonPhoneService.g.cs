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

                Task<List<ApiPersonPhoneResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiPersonPhoneResponseModel>> GetPhoneNumber(string phoneNumber);
        }
}

/*<Codenesium>
    <Hash>d2d8780a79062e07444a89c781e4a282</Hash>
</Codenesium>*/