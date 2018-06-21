using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IProductModelProductDescriptionCultureService
        {
                Task<CreateResponse<ApiProductModelProductDescriptionCultureResponseModel>> Create(
                        ApiProductModelProductDescriptionCultureRequestModel model);

                Task<ActionResponse> Update(int productModelID,
                                            ApiProductModelProductDescriptionCultureRequestModel model);

                Task<ActionResponse> Delete(int productModelID);

                Task<ApiProductModelProductDescriptionCultureResponseModel> Get(int productModelID);

                Task<List<ApiProductModelProductDescriptionCultureResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ec390ed86035c10227c36b5744cd4389</Hash>
</Codenesium>*/