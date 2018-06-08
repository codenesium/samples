using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLProductCostHistoryMapper
        {
                BOProductCostHistory MapModelToBO(
                        int productID,
                        ApiProductCostHistoryRequestModel model);

                ApiProductCostHistoryResponseModel MapBOToModel(
                        BOProductCostHistory boProductCostHistory);

                List<ApiProductCostHistoryResponseModel> MapBOToModel(
                        List<BOProductCostHistory> items);
        }
}

/*<Codenesium>
    <Hash>7b515d7d8b8d4560e64641186d53507d</Hash>
</Codenesium>*/