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

                Task<List<ApiErrorLogResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>473a432d943e21eceddd0448794ec504</Hash>
</Codenesium>*/