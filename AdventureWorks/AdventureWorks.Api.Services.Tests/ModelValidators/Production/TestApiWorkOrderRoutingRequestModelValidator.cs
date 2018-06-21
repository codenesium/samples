using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

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
    <Hash>434851fc71fb438e5616dc087fe12534</Hash>
</Codenesium>*/