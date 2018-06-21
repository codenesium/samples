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
        [Trait("Table", "Illustration")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiIllustrationRequestModelValidatorTest
        {
                public ApiIllustrationRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>246310a774fcb74287867b46a121fae1</Hash>
</Codenesium>*/