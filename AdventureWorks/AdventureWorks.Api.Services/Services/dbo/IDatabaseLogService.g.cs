using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IDatabaseLogService
        {
                Task<CreateResponse<ApiDatabaseLogResponseModel>> Create(
                        ApiDatabaseLogRequestModel model);

                Task<UpdateResponse<ApiDatabaseLogResponseModel>> Update(int databaseLogID,
                                                                          ApiDatabaseLogRequestModel model);

                Task<ActionResponse> Delete(int databaseLogID);

                Task<ApiDatabaseLogResponseModel> Get(int databaseLogID);

                Task<List<ApiDatabaseLogResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c2af15ac38b3fa3569c101901514e587</Hash>
</Codenesium>*/