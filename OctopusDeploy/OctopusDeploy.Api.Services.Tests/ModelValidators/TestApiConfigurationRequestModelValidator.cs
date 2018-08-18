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
	[Trait("Table", "Configuration")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiConfigurationRequestModelValidatorTest
	{
		public ApiConfigurationRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>1f70f29fdc174778acaa3c6369e3c492</Hash>
</Codenesium>*/