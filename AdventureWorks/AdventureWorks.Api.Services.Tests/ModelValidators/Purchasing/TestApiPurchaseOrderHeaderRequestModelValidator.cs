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
    <Hash>86fe6cff0eae4c359add42f52a788569</Hash>
</Codenesium>*/