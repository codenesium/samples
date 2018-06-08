using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>6562b6ab1c00519cd8d6d3f598b10911</Hash>
</Codenesium>*/