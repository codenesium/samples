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
	[Trait("Table", "CompositePrimaryKey")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCompositePrimaryKeyRequestModelValidatorTest
	{
		public ApiCompositePrimaryKeyRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a28585b98bd30d6cf68ca98db6e8f1ce</Hash>
</Codenesium>*/