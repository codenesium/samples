using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALProductModelProductDescriptionCultureMapper
        {
                ProductModelProductDescriptionCulture MapBOToEF(
                        BOProductModelProductDescriptionCulture bo);

                BOProductModelProductDescriptionCulture MapEFToBO(
                        ProductModelProductDescriptionCulture efProductModelProductDescriptionCulture);

                List<BOProductModelProductDescriptionCulture> MapEFToBO(
                        List<ProductModelProductDescriptionCulture> records);
        }
}

/*<Codenesium>
    <Hash>0bc746294a8a48ba0f4794dcfa459144</Hash>
</Codenesium>*/