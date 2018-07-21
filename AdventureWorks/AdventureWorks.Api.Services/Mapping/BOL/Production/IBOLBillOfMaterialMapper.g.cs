using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLBillOfMaterialMapper
        {
                BOBillOfMaterial MapModelToBO(
                        int billOfMaterialsID,
                        ApiBillOfMaterialRequestModel model);

                ApiBillOfMaterialResponseModel MapBOToModel(
                        BOBillOfMaterial boBillOfMaterial);

                List<ApiBillOfMaterialResponseModel> MapBOToModel(
                        List<BOBillOfMaterial> items);
        }
}

/*<Codenesium>
    <Hash>4160b4c0ccf4e5f07287efcb4607b764</Hash>
</Codenesium>*/