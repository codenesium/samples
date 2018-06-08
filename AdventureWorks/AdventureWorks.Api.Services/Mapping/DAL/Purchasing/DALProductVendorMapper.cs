using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALProductVendorMapper: DALAbstractProductVendorMapper, IDALProductVendorMapper
        {
                public DALProductVendorMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>c679778abc34d6eda7f41c395596ea04</Hash>
</Codenesium>*/