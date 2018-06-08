using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>1776bcc9721d77b17a8ee394676fb937</Hash>
</Codenesium>*/