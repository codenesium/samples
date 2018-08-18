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
    <Hash>2581e5ae2b8ef006138c27b47ea4b644</Hash>
</Codenesium>*/