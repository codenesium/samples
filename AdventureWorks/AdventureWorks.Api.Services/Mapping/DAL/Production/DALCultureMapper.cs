using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALCultureMapper: DALAbstractCultureMapper, IDALCultureMapper
        {
                public DALCultureMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>5854c6158ce1b56f7089ef154f60d5ad</Hash>
</Codenesium>*/