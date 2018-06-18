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

                Task<List<ApiProductProductPhotoResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>822f3ce75f5e0a56a5f6103d67d0b8fe</Hash>
</Codenesium>*/