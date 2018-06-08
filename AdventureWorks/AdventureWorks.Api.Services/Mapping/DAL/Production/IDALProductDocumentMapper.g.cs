using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALProductDocumentMapper
        {
                ProductDocument MapBOToEF(
                        BOProductDocument bo);

                BOProductDocument MapEFToBO(
                        ProductDocument efProductDocument);

                List<BOProductDocument> MapEFToBO(
                        List<ProductDocument> records);
        }
}

/*<Codenesium>
    <Hash>d78ddff19b488aa89927822b5c7cd424</Hash>
</Codenesium>*/