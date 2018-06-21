using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLProductCategoryMapper
        {
                BOProductCategory MapModelToBO(
                        int productCategoryID,
                        ApiProductCategoryRequestModel model);

                ApiProductCategoryResponseModel MapBOToModel(
                        BOProductCategory boProductCategory);

                List<ApiProductCategoryResponseModel> MapBOToModel(
                        List<BOProductCategory> items);
        }
}

/*<Codenesium>
    <Hash>d5e8ad3f9505edb01307f742ff07e0db</Hash>
</Codenesium>*/