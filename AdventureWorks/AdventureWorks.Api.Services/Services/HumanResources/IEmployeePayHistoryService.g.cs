using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiEmployeePayHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>a8bbf584f024c96d08879516b0519289</Hash>
</Codenesium>*/