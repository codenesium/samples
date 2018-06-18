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
        [Trait("Table", "BusinessEntityContact")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiBusinessEntityContactRequestModelValidatorTest
        {
                public ApiBusinessEntityContactRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>74006333b58ea5906a186755bc141c1b</Hash>
</Codenesium>*/