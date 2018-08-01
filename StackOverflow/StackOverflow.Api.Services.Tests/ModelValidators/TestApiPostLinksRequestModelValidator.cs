using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostLinks")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPostLinksRequestModelValidatorTest
	{
		public ApiPostLinksRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>9f3ba87414bba455e5ee8f3f9bf694eb</Hash>
</Codenesium>*/