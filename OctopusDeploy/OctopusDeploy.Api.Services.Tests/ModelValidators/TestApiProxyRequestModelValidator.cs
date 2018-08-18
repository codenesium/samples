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
	[Trait("Table", "Proxy")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiProxyRequestModelValidatorTest
	{
		public ApiProxyRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IProxyRepository> proxyRepository = new Mock<IProxyRepository>();
			proxyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Proxy()));

			var validator = new ApiProxyRequestModelValidator(proxyRepository.Object);
			await validator.ValidateCreateAsync(new ApiProxyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IProxyRepository> proxyRepository = new Mock<IProxyRepository>();
			proxyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Proxy()));

			var validator = new ApiProxyRequestModelValidator(proxyRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiProxyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IProxyRepository> proxyRepository = new Mock<IProxyRepository>();
			proxyRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Proxy>(new Proxy()));
			var validator = new ApiProxyRequestModelValidator(proxyRepository.Object);

			await validator.ValidateCreateAsync(new ApiProxyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IProxyRepository> proxyRepository = new Mock<IProxyRepository>();
			proxyRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Proxy>(null));
			var validator = new ApiProxyRequestModelValidator(proxyRepository.Object);

			await validator.ValidateCreateAsync(new ApiProxyRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IProxyRepository> proxyRepository = new Mock<IProxyRepository>();
			proxyRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Proxy>(new Proxy()));
			var validator = new ApiProxyRequestModelValidator(proxyRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiProxyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IProxyRepository> proxyRepository = new Mock<IProxyRepository>();
			proxyRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Proxy>(null));
			var validator = new ApiProxyRequestModelValidator(proxyRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiProxyRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>065942500a777e8c0ebf4d2921f066fd</Hash>
</Codenesium>*/