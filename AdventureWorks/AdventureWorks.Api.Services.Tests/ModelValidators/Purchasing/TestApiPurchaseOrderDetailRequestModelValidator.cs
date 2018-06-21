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
        [Trait("Table", "PurchaseOrderDetail")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiPurchaseOrderDetailRequestModelValidatorTest
        {
                public ApiPurchaseOrderDetailRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>c02f221013b6a207bdc3fa8b87b4490d</Hash>
</Codenesium>*/