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
    <Hash>e585ab493848ca8f2b245873eb0e7045</Hash>
</Codenesium>*/