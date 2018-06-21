using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLProductMapper
        {
                BOProduct MapModelToBO(
                        int productID,
                        ApiProductRequestModel model);

                ApiProductResponseModel MapBOToModel(
                        BOProduct boProduct);

                List<ApiProductResponseModel> MapBOToModel(
                        List<BOProduct> items);
        }
}

/*<Codenesium>
    <Hash>a7cd2c315f6658f28fdb70a201e3d1cd</Hash>
</Codenesium>*/