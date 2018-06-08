using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALProductPhotoMapper
        {
                ProductPhoto MapBOToEF(
                        BOProductPhoto bo);

                BOProductPhoto MapEFToBO(
                        ProductPhoto efProductPhoto);

                List<BOProductPhoto> MapEFToBO(
                        List<ProductPhoto> records);
        }
}

/*<Codenesium>
    <Hash>41f6e0fffb5be4b2fb4f8e7a7c3db85f</Hash>
</Codenesium>*/