using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLVendorMapper
        {
                BOVendor MapModelToBO(
                        int businessEntityID,
                        ApiVendorRequestModel model);

                ApiVendorResponseModel MapBOToModel(
                        BOVendor boVendor);

                List<ApiVendorResponseModel> MapBOToModel(
                        List<BOVendor> items);
        }
}

/*<Codenesium>
    <Hash>af31cb8ca3ff120ce6fbbe3953b7af66</Hash>
</Codenesium>*/