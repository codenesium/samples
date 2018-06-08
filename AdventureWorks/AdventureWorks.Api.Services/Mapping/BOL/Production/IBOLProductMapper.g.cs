using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>98a345c596dce276c13079cf6254f64c</Hash>
</Codenesium>*/