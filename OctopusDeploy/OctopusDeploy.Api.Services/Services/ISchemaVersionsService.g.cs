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

                Task<List<ApiSchemaVersionsResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>c0182331c63c24b400d5f12b55ab6138</Hash>
</Codenesium>*/