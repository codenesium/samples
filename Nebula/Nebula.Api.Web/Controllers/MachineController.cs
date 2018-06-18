using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;

namespace NebulaNS.Api.Web
{
        [Route("api/machines")]
        [ApiVersion("1.0")]
        public class MachineController: AbstractMachineController
        {
                public MachineController(
                        ApiSettings settings,
                        ILogger<MachineController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IMachineService machineService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               machineService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>eb7a49d683541925708f051146c73ba6</Hash>
</Codenesium>*/