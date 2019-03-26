using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
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

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VehicleCapabilitty")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVehicleCapabilittyServerRequestModelValidatorTest
	{
		public ApiVehicleCapabilittyServerRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>59f7509456aafd140846d85065e38ae8</Hash>
</Codenesium>*/