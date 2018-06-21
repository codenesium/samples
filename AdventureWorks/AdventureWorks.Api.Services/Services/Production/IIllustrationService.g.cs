using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IIllustrationService
        {
                Task<CreateResponse<ApiIllustrationResponseModel>> Create(
                        ApiIllustrationRequestModel model);

                Task<ActionResponse> Update(int illustrationID,
                                            ApiIllustrationRequestModel model);

                Task<ActionResponse> Delete(int illustrationID);

                Task<ApiIllustrationResponseModel> Get(int illustrationID);

                Task<List<ApiIllustrationResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiProductModelIllustrationResponseModel>> ProductModelIllustrations(int illustrationID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>caf7adbf06af65bd8a3eb5968c9fdaee</Hash>
</Codenesium>*/