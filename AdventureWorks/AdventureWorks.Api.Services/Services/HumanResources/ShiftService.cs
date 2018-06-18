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
                        ILogger<IShiftRepository> logger,
                        IShiftRepository shiftRepository,
                        IApiShiftRequestModelValidator shiftModelValidator,
                        IBOLShiftMapper bolshiftMapper,
                        IDALShiftMapper dalshiftMapper
                        ,
                        IBOLEmployeeDepartmentHistoryMapper bolEmployeeDepartmentHistoryMapper,
                        IDALEmployeeDepartmentHistoryMapper dalEmployeeDepartmentHistoryMapper

                        )
                        : base(logger,
                               shiftRepository,
                               shiftModelValidator,
                               bolshiftMapper,
                               dalshiftMapper
                               ,
                               bolEmployeeDepartmentHistoryMapper,
                               dalEmployeeDepartmentHistoryMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>5441f9518c5ea6905545d66a8f6a789b</Hash>
</Codenesium>*/