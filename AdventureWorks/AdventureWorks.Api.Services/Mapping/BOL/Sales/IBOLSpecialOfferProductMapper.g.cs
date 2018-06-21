using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLSpecialOfferProductMapper
        {
                BOSpecialOfferProduct MapModelToBO(
                        int specialOfferID,
                        ApiSpecialOfferProductRequestModel model);

                ApiSpecialOfferProductResponseModel MapBOToModel(
                        BOSpecialOfferProduct boSpecialOfferProduct);

                List<ApiSpecialOfferProductResponseModel> MapBOToModel(
                        List<BOSpecialOfferProduct> items);
        }
}

/*<Codenesium>
    <Hash>c5742cc051b81011f7b66d6a63e7fe54</Hash>
</Codenesium>*/