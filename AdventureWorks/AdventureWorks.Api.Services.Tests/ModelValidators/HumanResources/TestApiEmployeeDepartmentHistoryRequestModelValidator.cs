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
    <Hash>7a6af34985063b2874bd70185760e338</Hash>
</Codenesium>*/