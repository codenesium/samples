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

                Task<List<ApiEmployeePayHistoryResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>3b1f4ccf797a7ed2dc4b8f8b81a052a7</Hash>
</Codenesium>*/