using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLEmailAddressMapper
        {
                BOEmailAddress MapModelToBO(
                        int businessEntityID,
                        ApiEmailAddressRequestModel model);

                ApiEmailAddressResponseModel MapBOToModel(
                        BOEmailAddress boEmailAddress);

                List<ApiEmailAddressResponseModel> MapBOToModel(
                        List<BOEmailAddress> items);
        }
}

/*<Codenesium>
    <Hash>2bc84c205c79bae012f8be444ecc55bf</Hash>
</Codenesium>*/