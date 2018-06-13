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
                        ILogger<ProductProductPhotoRepository> logger,
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
    <Hash>62812a7e5dbb3ed67edf10c5b76302f5</Hash>
</Codenesium>*/