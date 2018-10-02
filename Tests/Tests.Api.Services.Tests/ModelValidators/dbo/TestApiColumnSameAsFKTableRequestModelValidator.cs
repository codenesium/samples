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
	public partial class ApiColumnSameAsFKTableRequestModelValidatorTest
	{
		public ApiColumnSameAsFKTableRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>8a7eafdc8186fe1b4bb7e48e873ba097</Hash>
</Codenesium>*/