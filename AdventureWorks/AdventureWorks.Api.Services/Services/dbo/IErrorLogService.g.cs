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

                Task<List<ApiErrorLogResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>2408eeb185138e30fc39c334a981187a</Hash>
</Codenesium>*/