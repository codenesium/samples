using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLProductSubcategoryMapper
        {
                BOProductSubcategory MapModelToBO(
                        int productSubcategoryID,
                        ApiProductSubcategoryRequestModel model);

                ApiProductSubcategoryResponseModel MapBOToModel(
                        BOProductSubcategory boProductSubcategory);

                List<ApiProductSubcategoryResponseModel> MapBOToModel(
                        List<BOProductSubcategory> items);
        }
}

/*<Codenesium>
    <Hash>b17b5c5bf3495745e26ba353fd005575</Hash>
</Codenesium>*/