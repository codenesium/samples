using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IErrorLogService
        {
                Task<CreateResponse<ApiErrorLogResponseModel>> Create(
                        ApiErrorLogRequestModel model);

                Task<ActionResponse> Update(int errorLogID,
                                            ApiErrorLogRequestModel model);

                Task<ActionResponse> Delete(int errorLogID);

                Task<ApiErrorLogResponseModel> Get(int errorLogID);

                Task<List<ApiErrorLogResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>7b96d483ee6cb90fcb71a4aede42f400</Hash>
</Codenesium>*/