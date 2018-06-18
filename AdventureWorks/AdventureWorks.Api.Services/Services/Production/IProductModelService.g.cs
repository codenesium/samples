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

                Task<List<ApiProductModelResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiProductModelResponseModel> ByName(string name);
                Task<List<ApiProductModelResponseModel>> ByCatalogDescription(string catalogDescription);
                Task<List<ApiProductModelResponseModel>> ByInstructions(string instructions);

                Task<List<ApiProductResponseModel>> Products(int productModelID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiProductModelIllustrationResponseModel>> ProductModelIllustrations(int productModelID, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultures(int productModelID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>7d54afc9ef3ccd92295e221630b3985a</Hash>
</Codenesium>*/