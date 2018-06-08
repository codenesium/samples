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

                Task<List<ApiProductProductPhotoResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>7431e8725bd6695d1c0923bd86acb958</Hash>
</Codenesium>*/