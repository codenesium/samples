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

                Task<List<ApiSchemaVersionsResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>8309502155f3d69ac1881dec5dda806a</Hash>
</Codenesium>*/