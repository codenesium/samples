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

                Task<UpdateResponse<ApiProductModelIllustrationResponseModel>> Update(int productModelID,
                                                                                       ApiProductModelIllustrationRequestModel model);

                Task<ActionResponse> Delete(int productModelID);

                Task<ApiProductModelIllustrationResponseModel> Get(int productModelID);

                Task<List<ApiProductModelIllustrationResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>4343156207ae4f6f9bf59d9977d921fb</Hash>
</Codenesium>*/