using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>0d74e751195102974d69c631781925a8</Hash>
</Codenesium>*/