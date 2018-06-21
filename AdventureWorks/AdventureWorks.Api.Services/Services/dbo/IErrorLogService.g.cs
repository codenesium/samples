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

                Task<ActionResponse> Update(int errorLogID,
                                            ApiErrorLogRequestModel model);

                Task<ActionResponse> Delete(int errorLogID);

                Task<ApiErrorLogResponseModel> Get(int errorLogID);

                Task<List<ApiErrorLogResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>a4a2c2b1c48f4d682e971578dfc4b94e</Hash>
</Codenesium>*/