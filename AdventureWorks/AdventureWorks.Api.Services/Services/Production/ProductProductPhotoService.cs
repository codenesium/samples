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
        public class ProductProductPhotoService: AbstractProductProductPhotoService, IProductProductPhotoService
        {
                public ProductProductPhotoService(
                        ILogger<IProductProductPhotoRepository> logger,
                        IProductProductPhotoRepository productProductPhotoRepository,
                        IApiProductProductPhotoRequestModelValidator productProductPhotoModelValidator,
                        IBOLProductProductPhotoMapper bolproductProductPhotoMapper,
                        IDALProductProductPhotoMapper dalproductProductPhotoMapper

                        )
                        : base(logger,
                               productProductPhotoRepository,
                               productProductPhotoModelValidator,
                               bolproductProductPhotoMapper,
                               dalproductProductPhotoMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>8365cf26c04752f2e03a4434f31f4971</Hash>
</Codenesium>*/