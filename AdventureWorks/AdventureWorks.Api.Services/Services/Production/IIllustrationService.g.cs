using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>6029110f23e6658f293bff2eb7458ea0</Hash>
</Codenesium>*/