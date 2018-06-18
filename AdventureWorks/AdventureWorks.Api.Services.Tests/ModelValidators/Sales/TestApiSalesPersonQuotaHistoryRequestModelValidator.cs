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
        [Trait("Table", "SalesPersonQuotaHistory")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSalesPersonQuotaHistoryRequestModelValidatorTest
        {
                public ApiSalesPersonQuotaHistoryRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>14d44950c482d6b1521f95fd74dd7e45</Hash>
</Codenesium>*/