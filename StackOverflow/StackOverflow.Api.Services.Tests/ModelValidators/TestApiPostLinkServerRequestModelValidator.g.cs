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
	public partial class ApiPostLinkServerRequestModelValidatorTest
	{
		public ApiPostLinkServerRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>25ec9b4a26295c7fb130880a351bf925</Hash>
</Codenesium>*/