using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>a27d4415d058065a9a3ec404660c5989</Hash>
</Codenesium>*/