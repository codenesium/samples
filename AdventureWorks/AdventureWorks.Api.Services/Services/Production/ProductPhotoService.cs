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
        public class ProductPhotoService : AbstractProductPhotoService, IProductPhotoService
        {
                public ProductPhotoService(
                        ILogger<IProductPhotoRepository> logger,
                        IProductPhotoRepository productPhotoRepository,
                        IApiProductPhotoRequestModelValidator productPhotoModelValidator,
                        IBOLProductPhotoMapper bolproductPhotoMapper,
                        IDALProductPhotoMapper dalproductPhotoMapper,
                        IBOLProductProductPhotoMapper bolProductProductPhotoMapper,
                        IDALProductProductPhotoMapper dalProductProductPhotoMapper
                        )
                        : base(logger,
                               productPhotoRepository,
                               productPhotoModelValidator,
                               bolproductPhotoMapper,
                               dalproductPhotoMapper,
                               bolProductProductPhotoMapper,
                               dalProductProductPhotoMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2367cd15321fde46b1a2e78bf27025a0</Hash>
</Codenesium>*/