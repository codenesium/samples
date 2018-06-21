using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLProductModelIllustrationMapper
        {
                BOProductModelIllustration MapModelToBO(
                        int productModelID,
                        ApiProductModelIllustrationRequestModel model);

                ApiProductModelIllustrationResponseModel MapBOToModel(
                        BOProductModelIllustration boProductModelIllustration);

                List<ApiProductModelIllustrationResponseModel> MapBOToModel(
                        List<BOProductModelIllustration> items);
        }
}

/*<Codenesium>
    <Hash>da7bb328b4599b43a2e97165b5633734</Hash>
</Codenesium>*/