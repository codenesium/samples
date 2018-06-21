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
        [Trait("Table", "EmployeeDepartmentHistory")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiEmployeeDepartmentHistoryRequestModelValidatorTest
        {
                public ApiEmployeeDepartmentHistoryRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>077db722423c542bbb250b13e6f114a9</Hash>
</Codenesium>*/