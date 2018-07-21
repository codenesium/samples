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
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SelfReference")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSelfReferenceRequestModelValidatorTest
        {
                public ApiSelfReferenceRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>bc2f26401496f4553dc986fed3360b46</Hash>
</Codenesium>*/