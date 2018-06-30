using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PostLinks")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPostLinksRequestModelValidatorTest
        {
                public ApiPostLinksRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>179c29d6b3d9e3ba86d0bfa967b87792</Hash>
</Codenesium>*/