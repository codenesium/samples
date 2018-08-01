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
	[Trait("Table", "SalesPersonQuotaHistory")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSalesPersonQuotaHistoryRequestModelValidatorTest
	{
		public ApiSalesPersonQuotaHistoryRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>6545bc1c32f4dcc4edaf669e63fb3518</Hash>
</Codenesium>*/