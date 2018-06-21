using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IProductPhotoService
        {
                Task<CreateResponse<ApiProductPhotoResponseModel>> Create(
                        ApiProductPhotoRequestModel model);

                Task<ActionResponse> Update(int productPhotoID,
                                            ApiProductPhotoRequestModel model);

                Task<ActionResponse> Delete(int productPhotoID);

                Task<ApiProductPhotoResponseModel> Get(int productPhotoID);

                Task<List<ApiProductPhotoResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiProductProductPhotoResponseModel>> ProductProductPhotoes(int productPhotoID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>323f372e8f39148f345d2db7c2812eaf</Hash>
</Codenesium>*/