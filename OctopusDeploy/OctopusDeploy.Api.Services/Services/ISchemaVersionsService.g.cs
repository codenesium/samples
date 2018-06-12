using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface ISchemaVersionsService
        {
                Task<CreateResponse<ApiSchemaVersionsResponseModel>> Create(
                        ApiSchemaVersionsRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiSchemaVersionsRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiSchemaVersionsResponseModel> Get(int id);

                Task<List<ApiSchemaVersionsResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>103861aa53e426d92950e0ed75510e6a</Hash>
</Codenesium>*/