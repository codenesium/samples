using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class ScrapReasonService : AbstractScrapReasonService, IScrapReasonService
        {
                public ScrapReasonService(
                        ILogger<IScrapReasonRepository> logger,
                        IScrapReasonRepository scrapReasonRepository,
                        IApiScrapReasonRequestModelValidator scrapReasonModelValidator,
                        IBOLScrapReasonMapper bolscrapReasonMapper,
                        IDALScrapReasonMapper dalscrapReasonMapper,
                        IBOLWorkOrderMapper bolWorkOrderMapper,
                        IDALWorkOrderMapper dalWorkOrderMapper
                        )
                        : base(logger,
                               scrapReasonRepository,
                               scrapReasonModelValidator,
                               bolscrapReasonMapper,
                               dalscrapReasonMapper,
                               bolWorkOrderMapper,
                               dalWorkOrderMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>520d65eeecc8c3cf962a76c03c28aaf0</Hash>
</Codenesium>*/