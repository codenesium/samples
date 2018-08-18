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
    <Hash>9e83542c2fea448c19eb5b4ed65b0454</Hash>
</Codenesium>*/