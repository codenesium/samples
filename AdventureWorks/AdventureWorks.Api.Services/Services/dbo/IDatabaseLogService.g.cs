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

                Task<List<ApiDatabaseLogResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5e7d68f61e46dc643faf91318aa1902e</Hash>
</Codenesium>*/