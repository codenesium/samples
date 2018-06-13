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

                Task<List<ApiProductModelResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiProductModelResponseModel> GetName(string name);
                Task<List<ApiProductModelResponseModel>> GetCatalogDescription(string catalogDescription);
                Task<List<ApiProductModelResponseModel>> GetInstructions(string instructions);

                Task<List<ApiProductResponseModel>> Products(int productModelID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiProductModelIllustrationResponseModel>> ProductModelIllustrations(int productModelID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultures(int productModelID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>08eccdc6d8f078b5516cac1f98b17084</Hash>
</Codenesium>*/