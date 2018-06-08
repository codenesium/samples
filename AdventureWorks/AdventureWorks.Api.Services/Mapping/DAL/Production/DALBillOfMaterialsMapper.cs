using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALBillOfMaterialsMapper: DALAbstractBillOfMaterialsMapper, IDALBillOfMaterialsMapper
        {
                public DALBillOfMaterialsMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>16fbdbda44a89b44bcac1e9525d623aa</Hash>
</Codenesium>*/