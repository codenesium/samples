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
        [Trait("Table", "EmployeePayHistory")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiEmployeePayHistoryRequestModelValidatorTest
        {
                public ApiEmployeePayHistoryRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>fcb9fe0dbf2b54efd17240246d824ef0</Hash>
</Codenesium>*/