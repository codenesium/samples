using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLProductModelMapper
        {
                BOProductModel MapModelToBO(
                        int productModelID,
                        ApiProductModelRequestModel model);

                ApiProductModelResponseModel MapBOToModel(
                        BOProductModel boProductModel);

                List<ApiProductModelResponseModel> MapBOToModel(
                        List<BOProductModel> items);
        }
}

/*<Codenesium>
    <Hash>13997d41ab66a2bd731ce70c7d074037</Hash>
</Codenesium>*/