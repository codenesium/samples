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
        public class ShiftService: AbstractShiftService, IShiftService
        {
                public ShiftService(
                        ILogger<ShiftRepository> logger,
                        IShiftRepository shiftRepository,
                        IApiShiftRequestModelValidator shiftModelValidator,
                        IBOLShiftMapper bolshiftMapper,
                        IDALShiftMapper dalshiftMapper)
                        : base(logger,
                               shiftRepository,
                               shiftModelValidator,
                               bolshiftMapper,
                               dalshiftMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>b0809e11ce12ebf7d08254e9ca1798b4</Hash>
</Codenesium>*/