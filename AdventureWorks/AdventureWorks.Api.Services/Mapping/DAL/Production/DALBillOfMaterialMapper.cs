using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALBillOfMaterialMapper : DALAbstractBillOfMaterialMapper, IDALBillOfMaterialMapper
        {
                public DALBillOfMaterialMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>d00143089f9dc5e4d061502f6f9fca1a</Hash>
</Codenesium>*/