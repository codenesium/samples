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
        [Trait("Table", "ProductListPriceHistory")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiProductListPriceHistoryRequestModelValidatorTest
        {
                public ApiProductListPriceHistoryRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>e5bc93e8925fe6c007f9bfaeabf8bd31</Hash>
</Codenesium>*/