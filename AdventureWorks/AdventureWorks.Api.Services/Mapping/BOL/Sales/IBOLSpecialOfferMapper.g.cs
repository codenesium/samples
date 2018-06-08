using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>0ae8ef032333647e7ade4281fa32d675</Hash>
</Codenesium>*/