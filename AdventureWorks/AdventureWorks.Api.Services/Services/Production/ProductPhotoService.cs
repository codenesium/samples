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
                        ILogger<IProductPhotoRepository> logger,
                        IProductPhotoRepository productPhotoRepository,
                        IApiProductPhotoRequestModelValidator productPhotoModelValidator,
                        IBOLProductPhotoMapper bolproductPhotoMapper,
                        IDALProductPhotoMapper dalproductPhotoMapper
                        ,
                        IBOLProductProductPhotoMapper bolProductProductPhotoMapper,
                        IDALProductProductPhotoMapper dalProductProductPhotoMapper

                        )
                        : base(logger,
                               productPhotoRepository,
                               productPhotoModelValidator,
                               bolproductPhotoMapper,
                               dalproductPhotoMapper
                               ,
                               bolProductProductPhotoMapper,
                               dalProductProductPhotoMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>79bd62e73ee4e74f3ada0915479af410</Hash>
</Codenesium>*/