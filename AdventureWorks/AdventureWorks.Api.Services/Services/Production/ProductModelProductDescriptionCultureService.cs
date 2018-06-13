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
        public class ProductModelProductDescriptionCultureService: AbstractProductModelProductDescriptionCultureService, IProductModelProductDescriptionCultureService
        {
                public ProductModelProductDescriptionCultureService(
                        ILogger<ProductModelProductDescriptionCultureRepository> logger,
                        IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository,
                        IApiProductModelProductDescriptionCultureRequestModelValidator productModelProductDescriptionCultureModelValidator,
                        IBOLProductModelProductDescriptionCultureMapper bolproductModelProductDescriptionCultureMapper,
                        IDALProductModelProductDescriptionCultureMapper dalproductModelProductDescriptionCultureMapper

                        )
                        : base(logger,
                               productModelProductDescriptionCultureRepository,
                               productModelProductDescriptionCultureModelValidator,
                               bolproductModelProductDescriptionCultureMapper,
                               dalproductModelProductDescriptionCultureMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>32bca333e348beb5a3ad2aa6c7b854c5</Hash>
</Codenesium>*/