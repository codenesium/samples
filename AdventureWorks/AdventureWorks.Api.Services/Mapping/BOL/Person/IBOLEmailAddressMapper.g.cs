using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>2cc6c4022d949c6c48fba15f069db92f</Hash>
</Codenesium>*/