using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALProductDescriptionMapper: DALAbstractProductDescriptionMapper, IDALProductDescriptionMapper
        {
                public DALProductDescriptionMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>bed29e08b7adb46eebf265dccdaee5d8</Hash>
</Codenesium>*/