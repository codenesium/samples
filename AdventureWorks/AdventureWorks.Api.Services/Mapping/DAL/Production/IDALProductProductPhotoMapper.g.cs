using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALProductProductPhotoMapper
        {
                ProductProductPhoto MapBOToEF(
                        BOProductProductPhoto bo);

                BOProductProductPhoto MapEFToBO(
                        ProductProductPhoto efProductProductPhoto);

                List<BOProductProductPhoto> MapEFToBO(
                        List<ProductProductPhoto> records);
        }
}

/*<Codenesium>
    <Hash>b67cd7f3a335846b7e4eac9a154b8077</Hash>
</Codenesium>*/