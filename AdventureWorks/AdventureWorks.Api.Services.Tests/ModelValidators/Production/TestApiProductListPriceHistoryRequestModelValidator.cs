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
    <Hash>921c18b59f93914da7a04b9d4ba3bd19</Hash>
</Codenesium>*/