using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>834e13d0ab1ec922bb71961d69818405</Hash>
</Codenesium>*/