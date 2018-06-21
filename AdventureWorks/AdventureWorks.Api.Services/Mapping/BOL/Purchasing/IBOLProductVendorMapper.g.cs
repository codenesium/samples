using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLProductVendorMapper
        {
                BOProductVendor MapModelToBO(
                        int productID,
                        ApiProductVendorRequestModel model);

                ApiProductVendorResponseModel MapBOToModel(
                        BOProductVendor boProductVendor);

                List<ApiProductVendorResponseModel> MapBOToModel(
                        List<BOProductVendor> items);
        }
}

/*<Codenesium>
    <Hash>a9d0e0280573685472df5536dee54628</Hash>
</Codenesium>*/