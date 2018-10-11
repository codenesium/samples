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
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PersonRef")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPersonRefRequestModelValidatorTest
	{
		public ApiPersonRefRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>830d831570cc7d334b573cb3484125da</Hash>
</Codenesium>*/