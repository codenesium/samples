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
	[Trait("Table", "ColumnSameAsFKTable")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiColumnSameAsFKTableServerRequestModelValidatorTest
	{
		public ApiColumnSameAsFKTableServerRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>7595f94d73bfa9e3933ac3ff2017427a</Hash>
</Codenesium>*/