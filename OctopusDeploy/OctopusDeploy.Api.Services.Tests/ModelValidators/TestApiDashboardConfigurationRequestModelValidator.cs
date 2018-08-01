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
    <Hash>b31c4718728f9a4fd05a416d30b397b1</Hash>
</Codenesium>*/