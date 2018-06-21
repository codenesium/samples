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
    <Hash>dd116ac4dc79b598c8d9ac44dfd5166c</Hash>
</Codenesium>*/