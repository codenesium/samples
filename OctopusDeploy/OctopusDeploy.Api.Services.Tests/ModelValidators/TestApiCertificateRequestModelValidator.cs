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
	[Trait("Table", "Certificate")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCertificateRequestModelValidatorTest
	{
		public ApiCertificateRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
			certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

			var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);
			await validator.ValidateCreateAsync(new ApiCertificateRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
			certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

			var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiCertificateRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		public async void Thumbprint_Create_length()
		{
			Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
			certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

			var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);
			await validator.ValidateCreateAsync(new ApiCertificateRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Thumbprint, new string('A', 129));
		}

		[Fact]
		public async void Thumbprint_Update_length()
		{
			Mock<ICertificateRepository> certificateRepository = new Mock<ICertificateRepository>();
			certificateRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Certificate()));

			var validator = new ApiCertificateRequestModelValidator(certificateRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiCertificateRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Thumbprint, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>d83afe22cda31b27832354f8c3c7772c</Hash>
</Codenesium>*/