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
	[Trait("Table", "ProductListPriceHistory")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiProductListPriceHistoryRequestModelValidatorTest
	{
		public ApiProductListPriceHistoryRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>2eed5d9f3f23ba1f594d59af933967de</Hash>
</Codenesium>*/