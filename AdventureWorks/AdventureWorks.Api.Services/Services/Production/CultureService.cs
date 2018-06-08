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
                        IDALCultureMapper dalcultureMapper)
                        : base(logger,
                               cultureRepository,
                               cultureModelValidator,
                               bolcultureMapper,
                               dalcultureMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>bc5301e592c6fe5c45108b0753b56014</Hash>
</Codenesium>*/