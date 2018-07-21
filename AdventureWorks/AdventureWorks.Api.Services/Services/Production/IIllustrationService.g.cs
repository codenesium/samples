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

                Task<UpdateResponse<ApiIllustrationResponseModel>> Update(int illustrationID,
                                                                           ApiIllustrationRequestModel model);

                Task<ActionResponse> Delete(int illustrationID);

                Task<ApiIllustrationResponseModel> Get(int illustrationID);

                Task<List<ApiIllustrationResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiProductModelIllustrationResponseModel>> ProductModelIllustrations(int illustrationID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>08b168f027b9f8a7e5513b1b5411851c</Hash>
</Codenesium>*/