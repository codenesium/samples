using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>f0d490509d50c6fdc0648dd6d224d9db</Hash>
</Codenesium>*/