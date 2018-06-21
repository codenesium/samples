using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>850c72e0b2b932757934c207b64cf643</Hash>
</Codenesium>*/