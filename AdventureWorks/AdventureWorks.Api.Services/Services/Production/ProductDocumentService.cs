using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ProductDocumentService: AbstractProductDocumentService, IProductDocumentService
        {
                public ProductDocumentService(
                        ILogger<ProductDocumentRepository> logger,
                        IProductDocumentRepository productDocumentRepository,
                        IApiProductDocumentRequestModelValidator productDocumentModelValidator,
                        IBOLProductDocumentMapper bolproductDocumentMapper,
                        IDALProductDocumentMapper dalproductDocumentMapper

                        )
                        : base(logger,
                               productDocumentRepository,
                               productDocumentModelValidator,
                               bolproductDocumentMapper,
                               dalproductDocumentMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>a84df22f766096275573d1c545c577d0</Hash>
</Codenesium>*/