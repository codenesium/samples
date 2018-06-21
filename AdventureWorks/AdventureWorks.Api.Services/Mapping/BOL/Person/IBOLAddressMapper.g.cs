using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLAddressMapper
        {
                BOAddress MapModelToBO(
                        int addressID,
                        ApiAddressRequestModel model);

                ApiAddressResponseModel MapBOToModel(
                        BOAddress boAddress);

                List<ApiAddressResponseModel> MapBOToModel(
                        List<BOAddress> items);
        }
}

/*<Codenesium>
    <Hash>f22433ca94833636439bdce65dd19a4b</Hash>
</Codenesium>*/