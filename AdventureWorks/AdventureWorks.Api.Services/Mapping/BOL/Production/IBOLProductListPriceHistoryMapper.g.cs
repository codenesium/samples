using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLProductListPriceHistoryMapper
        {
                BOProductListPriceHistory MapModelToBO(
                        int productID,
                        ApiProductListPriceHistoryRequestModel model);

                ApiProductListPriceHistoryResponseModel MapBOToModel(
                        BOProductListPriceHistory boProductListPriceHistory);

                List<ApiProductListPriceHistoryResponseModel> MapBOToModel(
                        List<BOProductListPriceHistory> items);
        }
}

/*<Codenesium>
    <Hash>64143f35da84ef70081365145443868c</Hash>
</Codenesium>*/