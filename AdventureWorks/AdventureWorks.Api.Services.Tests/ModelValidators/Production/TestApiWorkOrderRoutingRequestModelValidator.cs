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
    <Hash>3d979fe78ef8346225f4323d0c53683d</Hash>
</Codenesium>*/