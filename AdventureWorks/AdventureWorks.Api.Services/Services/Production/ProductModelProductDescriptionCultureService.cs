using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public partial class ProductModelProductDescriptionCultureService : AbstractProductModelProductDescriptionCultureService, IProductModelProductDescriptionCultureService
        {
                public ProductModelProductDescriptionCultureService(
                        ILogger<IProductModelProductDescriptionCultureRepository> logger,
                        IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
                        IApiProductModelProductDescriptionCultureRequestModelValidator productModelProductDescriptionCultureModelValidator,
                        IBOLProductModelProductDescriptionCultureMapper bolproductModelProductDescriptionCultureMapper,
                        IDALProductModelProductDescriptionCultureMapper dalproductModelProductDescriptionCultureMapper
                        )
                        : base(logger,
                               productModelProductDescriptionCultureRepository,
                               productModelProductDescriptionCultureModelValidator,
                               bolproductModelProductDescriptionCultureMapper,
                               dalproductModelProductDescriptionCultureMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>70b0cd1045306698e5e2e9d885761f38</Hash>
</Codenesium>*/