using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLProductModelProductDescriptionCultureMapper
        {
                BOProductModelProductDescriptionCulture MapModelToBO(
                        int productModelID,
                        ApiProductModelProductDescriptionCultureRequestModel model);

                ApiProductModelProductDescriptionCultureResponseModel MapBOToModel(
                        BOProductModelProductDescriptionCulture boProductModelProductDescriptionCulture);

                List<ApiProductModelProductDescriptionCultureResponseModel> MapBOToModel(
                        List<BOProductModelProductDescriptionCulture> items);
        }
}

/*<Codenesium>
    <Hash>e9c10c88304ae1e3575ac81febac28b6</Hash>
</Codenesium>*/