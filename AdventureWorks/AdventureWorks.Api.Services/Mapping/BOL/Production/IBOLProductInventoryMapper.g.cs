using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>994dd3624494f68ecb5b10a8533ce84e</Hash>
</Codenesium>*/