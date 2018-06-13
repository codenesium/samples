using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IProductProductPhotoService
        {
                Task<CreateResponse<ApiProductProductPhotoResponseModel>> Create(
                        ApiProductProductPhotoRequestModel model);

                Task<ActionResponse> Update(int productID,
                                            ApiProductProductPhotoRequestModel model);

                Task<ActionResponse> Delete(int productID);

                Task<ApiProductProductPhotoResponseModel> Get(int productID);

                Task<List<ApiProductProductPhotoResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>91d8b25f67cd09848df24fc96b996724</Hash>
</Codenesium>*/