using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>576f6372b20400565de9efc567e637c7</Hash>
</Codenesium>*/