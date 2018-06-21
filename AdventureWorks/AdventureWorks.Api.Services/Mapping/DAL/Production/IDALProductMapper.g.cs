using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALProductMapper
        {
                Product MapBOToEF(
                        BOProduct bo);

                BOProduct MapEFToBO(
                        Product efProduct);

                List<BOProduct> MapEFToBO(
                        List<Product> records);
        }
}

/*<Codenesium>
    <Hash>e4df6889d339f6e393528ff090705b4d</Hash>
</Codenesium>*/