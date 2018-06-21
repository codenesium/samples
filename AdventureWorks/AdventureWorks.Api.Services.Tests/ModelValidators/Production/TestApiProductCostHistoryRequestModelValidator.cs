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
    <Hash>5463315b37fbf3a5a96a402c4b7f9b35</Hash>
</Codenesium>*/