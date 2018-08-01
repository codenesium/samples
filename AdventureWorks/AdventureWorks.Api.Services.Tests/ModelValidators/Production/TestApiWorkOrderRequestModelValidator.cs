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
	[Trait("Table", "WorkOrder")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiWorkOrderRequestModelValidatorTest
	{
		public ApiWorkOrderRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>34f6fc9e824d4906ee595103691e5d11</Hash>
</Codenesium>*/