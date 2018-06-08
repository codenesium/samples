using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IProductModelService
        {
                Task<CreateResponse<ApiProductModelResponseModel>> Create(
                        ApiProductModelRequestModel model);

                Task<ActionResponse> Update(int productModelID,
                                            ApiProductModelRequestModel model);

                Task<ActionResponse> Delete(int productModelID);

                Task<ApiProductModelResponseModel> Get(int productModelID);

                Task<List<ApiProductModelResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiProductModelResponseModel> GetName(string name);
                Task<List<ApiProductModelResponseModel>> GetCatalogDescription(string catalogDescription);
                Task<List<ApiProductModelResponseModel>> GetInstructions(string instructions);
        }
}

/*<Codenesium>
    <Hash>4ffeed04bdb5848e429a86e8a8a863a6</Hash>
</Codenesium>*/