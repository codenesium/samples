using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLBusinessEntityAddressMapper
        {
                BOBusinessEntityAddress MapModelToBO(
                        int businessEntityID,
                        ApiBusinessEntityAddressRequestModel model);

                ApiBusinessEntityAddressResponseModel MapBOToModel(
                        BOBusinessEntityAddress boBusinessEntityAddress);

                List<ApiBusinessEntityAddressResponseModel> MapBOToModel(
                        List<BOBusinessEntityAddress> items);
        }
}

/*<Codenesium>
    <Hash>767ef2dc6db40cb406247845eed6c318</Hash>
</Codenesium>*/