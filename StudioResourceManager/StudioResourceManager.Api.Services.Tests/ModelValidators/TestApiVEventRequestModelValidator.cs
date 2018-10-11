using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VEvent")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVEventRequestModelValidatorTest
	{
		public ApiVEventRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>7d38007a5a2029ba7ad674d2d3410c07</Hash>
</Codenesium>*/