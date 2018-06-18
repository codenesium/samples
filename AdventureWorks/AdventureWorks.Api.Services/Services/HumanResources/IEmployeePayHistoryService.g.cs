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

                Task<List<ApiEmployeePayHistoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>449a977d099e71a065456d6436985e59</Hash>
</Codenesium>*/