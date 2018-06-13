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
                        IDALScrapReasonMapper dalscrapReasonMapper
                        ,
                        IBOLWorkOrderMapper bolWorkOrderMapper,
                        IDALWorkOrderMapper dalWorkOrderMapper

                        )
                        : base(logger,
                               scrapReasonRepository,
                               scrapReasonModelValidator,
                               bolscrapReasonMapper,
                               dalscrapReasonMapper
                               ,
                               bolWorkOrderMapper,
                               dalWorkOrderMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>acb55a6274eef24b011bb24b6459f1de</Hash>
</Codenesium>*/