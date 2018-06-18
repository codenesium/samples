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
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "KeyAllocation")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiKeyAllocationRequestModelValidatorTest
        {
                public ApiKeyAllocationRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>affe237f9b6bbc485b1c43ad23fc5444</Hash>
</Codenesium>*/