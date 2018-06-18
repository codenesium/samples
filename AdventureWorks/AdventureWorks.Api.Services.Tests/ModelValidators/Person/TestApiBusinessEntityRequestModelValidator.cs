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
        [Trait("Table", "BusinessEntity")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiBusinessEntityRequestModelValidatorTest
        {
                public ApiBusinessEntityRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>73add2200e3f498b4c388a4ca5286cf9</Hash>
</Codenesium>*/