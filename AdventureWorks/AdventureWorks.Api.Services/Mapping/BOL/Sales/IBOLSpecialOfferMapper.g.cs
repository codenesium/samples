using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLSpecialOfferMapper
        {
                BOSpecialOffer MapModelToBO(
                        int specialOfferID,
                        ApiSpecialOfferRequestModel model);

                ApiSpecialOfferResponseModel MapBOToModel(
                        BOSpecialOffer boSpecialOffer);

                List<ApiSpecialOfferResponseModel> MapBOToModel(
                        List<BOSpecialOffer> items);
        }
}

/*<Codenesium>
    <Hash>ef23aae533f3108d306beb3e3c1a4193</Hash>
</Codenesium>*/