using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDatabaseLogService
        {
                Task<CreateResponse<ApiDatabaseLogResponseModel>> Create(
                        ApiDatabaseLogRequestModel model);

                Task<ActionResponse> Update(int databaseLogID,
                                            ApiDatabaseLogRequestModel model);

                Task<ActionResponse> Delete(int databaseLogID);

                Task<ApiDatabaseLogResponseModel> Get(int databaseLogID);

                Task<List<ApiDatabaseLogResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>363b2addc4e27adc6890e715b8c1d452</Hash>
</Codenesium>*/