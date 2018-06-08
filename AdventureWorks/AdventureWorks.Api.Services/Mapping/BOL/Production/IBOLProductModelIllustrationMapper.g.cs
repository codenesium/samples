using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>a8413fff722925588752eee42dba2133</Hash>
</Codenesium>*/