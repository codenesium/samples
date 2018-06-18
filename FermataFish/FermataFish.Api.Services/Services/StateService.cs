using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class StateService: AbstractStateService, IStateService
        {
                public StateService(
                        ILogger<IStateRepository> logger,
                        IStateRepository stateRepository,
                        IApiStateRequestModelValidator stateModelValidator,
                        IBOLStateMapper bolstateMapper,
                        IDALStateMapper dalstateMapper
                        ,
                        IBOLStudioMapper bolStudioMapper,
                        IDALStudioMapper dalStudioMapper

                        )
                        : base(logger,
                               stateRepository,
                               stateModelValidator,
                               bolstateMapper,
                               dalstateMapper
                               ,
                               bolStudioMapper,
                               dalStudioMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>9db6cfbdef94b7063d7ecda8d1d1f3a1</Hash>
</Codenesium>*/