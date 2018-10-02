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
	[Trait("Table", "PostLink")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPostLinkRequestModelValidatorTest
	{
		public ApiPostLinkRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>f96c474900910d8d623d744bc20db384</Hash>
</Codenesium>*/