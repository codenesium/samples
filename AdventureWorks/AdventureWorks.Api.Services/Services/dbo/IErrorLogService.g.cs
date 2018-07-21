using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IErrorLogService
        {
                Task<CreateResponse<ApiErrorLogResponseModel>> Create(
                        ApiErrorLogRequestModel model);

                Task<UpdateResponse<ApiErrorLogResponseModel>> Update(int errorLogID,
                                                                       ApiErrorLogRequestModel model);

                Task<ActionResponse> Delete(int errorLogID);

                Task<ApiErrorLogResponseModel> Get(int errorLogID);

                Task<List<ApiErrorLogResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>4c29ad4868bc64134f9072a7cc254ae6</Hash>
</Codenesium>*/