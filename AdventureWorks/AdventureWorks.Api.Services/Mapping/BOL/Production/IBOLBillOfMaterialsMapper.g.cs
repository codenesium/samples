using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>26f1c37f34286ade06b7571114a0c033</Hash>
</Codenesium>*/