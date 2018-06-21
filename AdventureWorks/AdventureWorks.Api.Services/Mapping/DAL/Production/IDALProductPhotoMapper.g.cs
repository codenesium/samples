using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>9226cfe72cad29ca37da03afe0b3061f</Hash>
</Codenesium>*/