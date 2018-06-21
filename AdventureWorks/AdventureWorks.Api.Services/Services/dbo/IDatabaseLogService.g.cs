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

                Task<ActionResponse> Update(int databaseLogID,
                                            ApiDatabaseLogRequestModel model);

                Task<ActionResponse> Delete(int databaseLogID);

                Task<ApiDatabaseLogResponseModel> Get(int databaseLogID);

                Task<List<ApiDatabaseLogResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9f483eba1f690f609a95957b2707ae3e</Hash>
</Codenesium>*/