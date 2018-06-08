using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>b9db7587c693f6faf5b22c3cd16209bb</Hash>
</Codenesium>*/