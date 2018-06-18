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
        [Trait("Table", "WorkOrder")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiWorkOrderRequestModelValidatorTest
        {
                public ApiWorkOrderRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>61896df84e066c494355c9c00836b19a</Hash>
</Codenesium>*/