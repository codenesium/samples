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
                        ILogger<StateRepository> logger,
                        IStateRepository stateRepository,
                        IApiStateRequestModelValidator stateModelValidator,
                        IBOLStateMapper bolstateMapper,
                        IDALStateMapper dalstateMapper)
                        : base(logger,
                               stateRepository,
                               stateModelValidator,
                               bolstateMapper,
                               dalstateMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>02837e84498e3fd1b4dc728b6e97891d</Hash>
</Codenesium>*/