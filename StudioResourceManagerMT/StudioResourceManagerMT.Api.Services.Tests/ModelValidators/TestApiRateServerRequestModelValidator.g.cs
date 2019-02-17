using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Rate")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiRateServerRequestModelValidatorTest
	{
		public ApiRateServerRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>fb72fa0b7ecca98212879c35df458d22</Hash>
</Codenesium>*/