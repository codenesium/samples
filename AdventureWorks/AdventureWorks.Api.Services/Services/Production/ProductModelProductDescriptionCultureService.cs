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
                               dalproductModelProductDescriptionCultureMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>63eba0302f4cb7b7765cf213625bf2d0</Hash>
</Codenesium>*/