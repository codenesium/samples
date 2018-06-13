using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IProductModelIllustrationService
        {
                Task<CreateResponse<ApiProductModelIllustrationResponseModel>> Create(
                        ApiProductModelIllustrationRequestModel model);

                Task<ActionResponse> Update(int productModelID,
                                            ApiProductModelIllustrationRequestModel model);

                Task<ActionResponse> Delete(int productModelID);

                Task<ApiProductModelIllustrationResponseModel> Get(int productModelID);

                Task<List<ApiProductModelIllustrationResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>70f40b907832809851a15280cff47366</Hash>
</Codenesium>*/