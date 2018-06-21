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
    <Hash>fa45d23a5ecb4823b9afa009cbb06c60</Hash>
</Codenesium>*/