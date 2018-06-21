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
        [Trait("Table", "BusinessEntityAddress")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiBusinessEntityAddressRequestModelValidatorTest
        {
                public ApiBusinessEntityAddressRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>5b78a25279769e1f92dd400794e0794f</Hash>
</Codenesium>*/