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
    <Hash>c2a1627a8a5c68c7724173e46e43353b</Hash>
</Codenesium>*/