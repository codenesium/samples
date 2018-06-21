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
    <Hash>5f2e8ec7e8ea5200b7b77f954b04dd7d</Hash>
</Codenesium>*/