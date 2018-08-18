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
	[Trait("Table", "Votes")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVotesRequestModelValidatorTest
	{
		public ApiVotesRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>6968cb7eb812fa62ea6526b822da852c</Hash>
</Codenesium>*/