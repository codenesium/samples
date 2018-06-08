using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLIllustrationMapper
        {
                BOIllustration MapModelToBO(
                        int illustrationID,
                        ApiIllustrationRequestModel model);

                ApiIllustrationResponseModel MapBOToModel(
                        BOIllustration boIllustration);

                List<ApiIllustrationResponseModel> MapBOToModel(
                        List<BOIllustration> items);
        }
}

/*<Codenesium>
    <Hash>b2447b64f3d69587afa4a81640b4d957</Hash>
</Codenesium>*/