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

                Task<List<ApiProductModelIllustrationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>e21c48a0d198bd66973adafb7ff92285</Hash>
</Codenesium>*/