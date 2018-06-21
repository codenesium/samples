using Codenesium.DataConversionExtensions.AspNetCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Services
{
        public class StateService : AbstractStateService, IStateService
        {
                public StateService(
                        ILogger<IStateRepository> logger,
                        IStateRepository stateRepository,
                        IApiStateRequestModelValidator stateModelValidator,
                        IBOLStateMapper bolstateMapper,
                        IDALStateMapper dalstateMapper,
                        IBOLStudioMapper bolStudioMapper,
                        IDALStudioMapper dalStudioMapper
                        )
                        : base(logger,
                               stateRepository,
                               stateModelValidator,
                               bolstateMapper,
                               dalstateMapper,
                               bolStudioMapper,
                               dalStudioMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ac8f17eadf4c5f269d5e543213ee9017</Hash>
</Codenesium>*/