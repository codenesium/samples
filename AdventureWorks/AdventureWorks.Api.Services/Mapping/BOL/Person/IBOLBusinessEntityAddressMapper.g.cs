using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>1c2442a2ee71fc40362d924c6a064124</Hash>
</Codenesium>*/