using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>3a539e7a8683bf3a21281196d1b40472</Hash>
</Codenesium>*/