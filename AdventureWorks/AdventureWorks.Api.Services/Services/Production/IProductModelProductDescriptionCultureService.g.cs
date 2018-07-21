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

                Task<UpdateResponse<ApiProductModelProductDescriptionCultureResponseModel>> Update(int productModelID,
                                                                                                    ApiProductModelProductDescriptionCultureRequestModel model);

                Task<ActionResponse> Delete(int productModelID);

                Task<ApiProductModelProductDescriptionCultureResponseModel> Get(int productModelID);

                Task<List<ApiProductModelProductDescriptionCultureResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>a94aa51b65a59cfd0302297202fbb058</Hash>
</Codenesium>*/