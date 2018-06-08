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
        public class ProductPhotoService: AbstractProductPhotoService, IProductPhotoService
        {
                public ProductPhotoService(
                        ILogger<ProductPhotoRepository> logger,
                        IProductPhotoRepository productPhotoRepository,
                        IApiProductPhotoRequestModelValidator productPhotoModelValidator,
                        IBOLProductPhotoMapper bolproductPhotoMapper,
                        IDALProductPhotoMapper dalproductPhotoMapper)
                        : base(logger,
                               productPhotoRepository,
                               productPhotoModelValidator,
                               bolproductPhotoMapper,
                               dalproductPhotoMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8e76fdc273e21d7a492944724613b7f1</Hash>
</Codenesium>*/