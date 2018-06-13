using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IEmployeePayHistoryService
        {
                Task<CreateResponse<ApiEmployeePayHistoryResponseModel>> Create(
                        ApiEmployeePayHistoryRequestModel model);

                Task<ActionResponse> Update(int businessEntityID,
                                            ApiEmployeePayHistoryRequestModel model);

                Task<ActionResponse> Delete(int businessEntityID);

                Task<ApiEmployeePayHistoryResponseModel> Get(int businessEntityID);

                Task<List<ApiEmployeePayHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>56ee0322b1dca1692a812863a3fb2fe9</Hash>
</Codenesium>*/