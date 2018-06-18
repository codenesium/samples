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

                Task<List<ApiProductModelIllustrationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9f9a3f0a9aec236181ce26a0daaa4f6c</Hash>
</Codenesium>*/