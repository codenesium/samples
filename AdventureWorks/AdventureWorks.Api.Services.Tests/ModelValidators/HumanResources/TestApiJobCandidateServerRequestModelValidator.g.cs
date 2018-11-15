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
	[Trait("Table", "JobCandidate")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiJobCandidateServerRequestModelValidatorTest
	{
		public ApiJobCandidateServerRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>7bc3d7bbcc7a879254d0680cdf7da2b2</Hash>
</Codenesium>*/