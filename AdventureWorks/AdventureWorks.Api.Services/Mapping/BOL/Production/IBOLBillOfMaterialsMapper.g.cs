using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLBillOfMaterialsMapper
        {
                BOBillOfMaterials MapModelToBO(
                        int billOfMaterialsID,
                        ApiBillOfMaterialsRequestModel model);

                ApiBillOfMaterialsResponseModel MapBOToModel(
                        BOBillOfMaterials boBillOfMaterials);

                List<ApiBillOfMaterialsResponseModel> MapBOToModel(
                        List<BOBillOfMaterials> items);
        }
}

/*<Codenesium>
    <Hash>706ffe8c1cf5700b3beda01293ffe294</Hash>
</Codenesium>*/