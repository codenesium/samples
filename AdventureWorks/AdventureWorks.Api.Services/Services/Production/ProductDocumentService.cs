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
                        IDALProductDocumentMapper dalproductDocumentMapper)
                        : base(logger,
                               productDocumentRepository,
                               productDocumentModelValidator,
                               bolproductDocumentMapper,
                               dalproductDocumentMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>71c87a3dd1b9a294d736315d9348ed71</Hash>
</Codenesium>*/