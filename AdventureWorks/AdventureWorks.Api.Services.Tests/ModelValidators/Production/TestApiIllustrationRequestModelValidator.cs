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
    <Hash>fdade9fec44622357e49356a9b722d6e</Hash>
</Codenesium>*/