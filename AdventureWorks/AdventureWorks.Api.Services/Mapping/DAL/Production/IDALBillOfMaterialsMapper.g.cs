using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>980ec7b0fa9131c30c70efc180069352</Hash>
</Codenesium>*/