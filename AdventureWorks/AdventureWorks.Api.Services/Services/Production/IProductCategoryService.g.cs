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

                Task<List<ApiProductCategoryResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiProductCategoryResponseModel> ByName(string name);

                Task<List<ApiProductSubcategoryResponseModel>> ProductSubcategories(int productCategoryID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>460b202b3f6a7b6926ed5fde03e62a36</Hash>
</Codenesium>*/