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
	[Trait("Table", "Mutex")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiMutexRequestModelValidatorTest
	{
		public ApiMutexRequestModelValidatorTest()
		{
		}
	}
}

/*<Codenesium>
    <Hash>93f67badb31dd3883516ed1a878f5655</Hash>
</Codenesium>*/