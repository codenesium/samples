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
        public class CultureService: AbstractCultureService, ICultureService
        {
                public CultureService(
                        ILogger<CultureRepository> logger,
                        ICultureRepository cultureRepository,
                        IApiCultureRequestModelValidator cultureModelValidator,
                        IBOLCultureMapper bolcultureMapper,
                        IDALCultureMapper dalcultureMapper
                        ,
                        IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper,
                        IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper

                        )
                        : base(logger,
                               cultureRepository,
                               cultureModelValidator,
                               bolcultureMapper,
                               dalcultureMapper
                               ,
                               bolProductModelProductDescriptionCultureMapper,
                               dalProductModelProductDescriptionCultureMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>cfa0705da57ca5750aafb858aabf5810</Hash>
</Codenesium>*/