using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductModelIllustration")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiProductModelIllustrationRequestModelValidatorTest
	{
		public ApiProductModelIllustrationRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>5cb2de7a20d6970fd6d234daca9546eb</Hash>
</Codenesium>*/