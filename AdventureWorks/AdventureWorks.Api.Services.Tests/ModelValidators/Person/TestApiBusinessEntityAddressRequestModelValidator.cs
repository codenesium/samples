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
        [Trait("Table", "BusinessEntityAddress")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiBusinessEntityAddressRequestModelValidatorTest
        {
                public ApiBusinessEntityAddressRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>11a3c1d24a6c4f7805ebf3793788a688</Hash>
</Codenesium>*/