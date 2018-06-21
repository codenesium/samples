using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>0f82d55bdd1b7ada3dbee3fb5549f1d3</Hash>
</Codenesium>*/