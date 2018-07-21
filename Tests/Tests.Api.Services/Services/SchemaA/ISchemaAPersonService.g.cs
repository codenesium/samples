using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface ISchemaAPersonService
        {
                Task<CreateResponse<ApiSchemaAPersonResponseModel>> Create(
                        ApiSchemaAPersonRequestModel model);

                Task<UpdateResponse<ApiSchemaAPersonResponseModel>> Update(int id,
                                                                            ApiSchemaAPersonRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiSchemaAPersonResponseModel> Get(int id);

                Task<List<ApiSchemaAPersonResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>4c47e8ae260ce77c6f8d550ccb34bcc1</Hash>
</Codenesium>*/