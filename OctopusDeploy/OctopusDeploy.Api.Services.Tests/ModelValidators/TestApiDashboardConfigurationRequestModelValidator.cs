using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "DashboardConfiguration")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiDashboardConfigurationRequestModelValidatorTest
	{
		public ApiDashboardConfigurationRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>cf18c46f091e3b20b3d0f27588c58d9d</Hash>
</Codenesium>*/