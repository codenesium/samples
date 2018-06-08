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
        public class ScrapReasonService: AbstractScrapReasonService, IScrapReasonService
        {
                public ScrapReasonService(
                        ILogger<ScrapReasonRepository> logger,
                        IScrapReasonRepository scrapReasonRepository,
                        IApiScrapReasonRequestModelValidator scrapReasonModelValidator,
                        IBOLScrapReasonMapper bolscrapReasonMapper,
                        IDALScrapReasonMapper dalscrapReasonMapper)
                        : base(logger,
                               scrapReasonRepository,
                               scrapReasonModelValidator,
                               bolscrapReasonMapper,
                               dalscrapReasonMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d1b90b93d8a66d74573d802b6e163fc3</Hash>
</Codenesium>*/