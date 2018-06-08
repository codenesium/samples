using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>85eb9fe0552798170e3b7f4796e26c2f</Hash>
</Codenesium>*/