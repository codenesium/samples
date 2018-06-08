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

                Task<List<ApiProductPhotoResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>bc51320fc4568eec75071149158458be</Hash>
</Codenesium>*/