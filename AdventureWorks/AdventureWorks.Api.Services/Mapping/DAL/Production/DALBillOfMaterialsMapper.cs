using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALBillOfMaterialsMapper : DALAbstractBillOfMaterialsMapper, IDALBillOfMaterialsMapper
        {
                public DALBillOfMaterialsMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>cce88a769882f9cace06840c9d7d6ad4</Hash>
</Codenesium>*/