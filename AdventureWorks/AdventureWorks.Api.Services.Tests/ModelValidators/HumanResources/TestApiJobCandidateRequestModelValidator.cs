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
        [Trait("Table", "JobCandidate")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiJobCandidateRequestModelValidatorTest
        {
                public ApiJobCandidateRequestModelValidatorTest()
                {
                }
        }
}

/*<Codenesium>
    <Hash>71cac5753cfc624b09c839507bebaf18</Hash>
</Codenesium>*/