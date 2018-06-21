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
        [Trait("Table", "ProductProductPhoto")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiProductProductPhotoRequestModelValidatorTest
        {
                public ApiProductProductPhotoRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>2c2124df094d35056b65345377bfb2a3</Hash>
</Codenesium>*/