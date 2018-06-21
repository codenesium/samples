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
        public class ProductProductPhotoService : AbstractProductProductPhotoService, IProductProductPhotoService
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
                               dalproductProductPhotoMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>161b015c2992974de59c2d30c8b5bb4c</Hash>
</Codenesium>*/