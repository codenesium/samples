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
        [Trait("Table", "PurchaseOrderHeader")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPurchaseOrderHeaderRequestModelValidatorTest
        {
                public ApiPurchaseOrderHeaderRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>50c4d6ba36645a7896ec8bedf9283f5d</Hash>
</Codenesium>*/