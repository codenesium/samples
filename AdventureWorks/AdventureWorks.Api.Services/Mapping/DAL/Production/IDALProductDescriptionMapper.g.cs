using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALProductDescriptionMapper
        {
                ProductDescription MapBOToEF(
                        BOProductDescription bo);

                BOProductDescription MapEFToBO(
                        ProductDescription efProductDescription);

                List<BOProductDescription> MapEFToBO(
                        List<ProductDescription> records);
        }
}

/*<Codenesium>
    <Hash>f2558fb43a383e38b7442baa8a5a2125</Hash>
</Codenesium>*/