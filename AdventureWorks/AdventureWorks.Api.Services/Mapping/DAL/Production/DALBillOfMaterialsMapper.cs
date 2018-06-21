using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALBillOfMaterialsMapper : DALAbstractBillOfMaterialsMapper, IDALBillOfMaterialsMapper
        {
                public DALBillOfMaterialsMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>1a677815bfb39ad60ce6878ad62caea8</Hash>
</Codenesium>*/