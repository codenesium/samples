using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>c73254481a454f69aeeb03f0d5737dee</Hash>
</Codenesium>*/