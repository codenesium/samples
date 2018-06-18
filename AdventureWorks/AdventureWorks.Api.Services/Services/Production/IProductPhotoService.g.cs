using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>78d645b7ba3c12964ff8f46391d25250</Hash>
</Codenesium>*/