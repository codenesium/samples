using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IProductDescriptionService
        {
                Task<CreateResponse<ApiProductDescriptionResponseModel>> Create(
                        ApiProductDescriptionRequestModel model);

                Task<ActionResponse> Update(int productDescriptionID,
                                            ApiProductDescriptionRequestModel model);

                Task<ActionResponse> Delete(int productDescriptionID);

                Task<ApiProductDescriptionResponseModel> Get(int productDescriptionID);

                Task<List<ApiProductDescriptionResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiProductModelProductDescriptionCultureResponseModel>> ProductModelProductDescriptionCultures(int productDescriptionID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5fb17864c76a3dcb5dc3c84220960967</Hash>
</Codenesium>*/