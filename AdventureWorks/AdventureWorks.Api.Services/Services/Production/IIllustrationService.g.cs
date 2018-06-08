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

                Task<List<ApiIllustrationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>6ec28f8eccf58286a20a0854e70c6438</Hash>
</Codenesium>*/