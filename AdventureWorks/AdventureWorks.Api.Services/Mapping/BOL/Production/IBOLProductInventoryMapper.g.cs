using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLProductInventoryMapper
        {
                BOProductInventory MapModelToBO(
                        int productID,
                        ApiProductInventoryRequestModel model);

                ApiProductInventoryResponseModel MapBOToModel(
                        BOProductInventory boProductInventory);

                List<ApiProductInventoryResponseModel> MapBOToModel(
                        List<BOProductInventory> items);
        }
}

/*<Codenesium>
    <Hash>2fd938a3cbd58346d423d262f76d266a</Hash>
</Codenesium>*/