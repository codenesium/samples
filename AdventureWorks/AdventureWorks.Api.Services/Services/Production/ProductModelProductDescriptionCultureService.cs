using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class ProductModelProductDescriptionCultureService : AbstractProductModelProductDescriptionCultureService, IProductModelProductDescriptionCultureService
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
    <Hash>6c1eb34309e13af4d5f66fd6baa7e23d</Hash>
</Codenesium>*/