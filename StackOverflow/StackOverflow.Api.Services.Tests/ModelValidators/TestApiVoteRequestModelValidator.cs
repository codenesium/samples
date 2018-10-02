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
	[Trait("Table", "Vote")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVoteRequestModelValidatorTest
	{
		public ApiVoteRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>5990bc86449f3f37e09c519cfb245096</Hash>
</Codenesium>*/