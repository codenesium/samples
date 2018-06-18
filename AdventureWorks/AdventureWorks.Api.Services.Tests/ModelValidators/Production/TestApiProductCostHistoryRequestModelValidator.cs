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
        [Trait("Table", "ProductCostHistory")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiProductCostHistoryRequestModelValidatorTest
        {
                public ApiProductCostHistoryRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>8fbd5330724ca94fb32dd248a6a24e7d</Hash>
</Codenesium>*/