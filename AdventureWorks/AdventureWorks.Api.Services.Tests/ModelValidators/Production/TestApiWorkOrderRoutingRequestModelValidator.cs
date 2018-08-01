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
	[Trait("Table", "WorkOrderRouting")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiWorkOrderRoutingRequestModelValidatorTest
	{
		public ApiWorkOrderRoutingRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>50d3b8c16bdc25722262a82d7a4495aa</Hash>
</Codenesium>*/