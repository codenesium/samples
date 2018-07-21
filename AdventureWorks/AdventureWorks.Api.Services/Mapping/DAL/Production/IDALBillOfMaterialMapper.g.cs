using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALBillOfMaterialMapper
        {
                BillOfMaterial MapBOToEF(
                        BOBillOfMaterial bo);

                BOBillOfMaterial MapEFToBO(
                        BillOfMaterial efBillOfMaterial);

                List<BOBillOfMaterial> MapEFToBO(
                        List<BillOfMaterial> records);
        }
}

/*<Codenesium>
    <Hash>2bfcd2d0ce1f10f5b4105f6a8a06209b</Hash>
</Codenesium>*/