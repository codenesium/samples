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
	[Trait("Table", "VehicleCapabilities")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVehicleCapabilitiesServerRequestModelValidatorTest
	{
		public ApiVehicleCapabilitiesServerRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>ae3d566a698f79931ffca6c005b9acc1</Hash>
</Codenesium>*/