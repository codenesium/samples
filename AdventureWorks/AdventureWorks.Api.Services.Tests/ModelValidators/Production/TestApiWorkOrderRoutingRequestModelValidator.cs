using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using System.Linq;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "WorkOrderRouting")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiWorkOrderRoutingRequestModelValidatorTest
        {
                public ApiWorkOrderRoutingRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>ef9c97c93d6576b881c83d9afa938513</Hash>
</Codenesium>*/