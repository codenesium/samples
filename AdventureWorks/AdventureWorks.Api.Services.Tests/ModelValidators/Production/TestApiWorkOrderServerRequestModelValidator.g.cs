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
	public partial class ApiWorkOrderServerRequestModelValidatorTest
	{
		public ApiWorkOrderServerRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>46a29ea16079cc96e6ea53e1453ae5ba</Hash>
</Codenesium>*/