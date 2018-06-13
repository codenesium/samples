using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IProductCategoryService
        {
                Task<CreateResponse<ApiProductCategoryResponseModel>> Create(
                        ApiProductCategoryRequestModel model);

                Task<ActionResponse> Update(int productCategoryID,
                                            ApiProductCategoryRequestModel model);

                Task<ActionResponse> Delete(int productCategoryID);

                Task<ApiProductCategoryResponseModel> Get(int productCategoryID);

                Task<List<ApiProductCategoryResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiProductCategoryResponseModel> GetName(string name);

                Task<List<ApiProductSubcategoryResponseModel>> ProductSubcategories(int productCategoryID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>27fa1f97c6e7b5843d85f78b0b42935e</Hash>
</Codenesium>*/