using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALBillOfMaterialsMapper
        {
                BillOfMaterials MapBOToEF(
                        BOBillOfMaterials bo);

                BOBillOfMaterials MapEFToBO(
                        BillOfMaterials efBillOfMaterials);

                List<BOBillOfMaterials> MapEFToBO(
                        List<BillOfMaterials> records);
        }
}

/*<Codenesium>
    <Hash>d10859a93288a52655f05b5f48079a3a</Hash>
</Codenesium>*/