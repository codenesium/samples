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
        public class ProductModelService: AbstractProductModelService, IProductModelService
        {
                public ProductModelService(
                        ILogger<ProductModelRepository> logger,
                        IProductModelRepository productModelRepository,
                        IApiProductModelRequestModelValidator productModelModelValidator,
                        IBOLProductModelMapper bolproductModelMapper,
                        IDALProductModelMapper dalproductModelMapper
                        ,
                        IBOLProductMapper bolProductMapper,
                        IDALProductMapper dalProductMapper
                        ,
                        IBOLProductModelIllustrationMapper bolProductModelIllustrationMapper,
                        IDALProductModelIllustrationMapper dalProductModelIllustrationMapper
                        ,
                        IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper,
                        IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper

                        )
                        : base(logger,
                               productModelRepository,
                               productModelModelValidator,
                               bolproductModelMapper,
                               dalproductModelMapper
                               ,
                               bolProductMapper,
                               dalProductMapper
                               ,
                               bolProductModelIllustrationMapper,
                               dalProductModelIllustrationMapper
                               ,
                               bolProductModelProductDescriptionCultureMapper,
                               dalProductModelProductDescriptionCultureMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>c1f1ef10c324ba8b05c8c263ad19e077</Hash>
</Codenesium>*/