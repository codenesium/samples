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
	[Trait("Table", "OffCapability")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiOffCapabilityServerRequestModelValidatorTest
	{
		public ApiOffCapabilityServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IOffCapabilityRepository> offCapabilityRepository = new Mock<IOffCapabilityRepository>();
			offCapabilityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OffCapability()));

			var validator = new ApiOffCapabilityServerRequestModelValidator(offCapabilityRepository.Object);
			await validator.ValidateCreateAsync(new ApiOffCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IOffCapabilityRepository> offCapabilityRepository = new Mock<IOffCapabilityRepository>();
			offCapabilityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OffCapability()));

			var validator = new ApiOffCapabilityServerRequestModelValidator(offCapabilityRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOffCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IOffCapabilityRepository> offCapabilityRepository = new Mock<IOffCapabilityRepository>();
			offCapabilityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OffCapability()));

			var validator = new ApiOffCapabilityServerRequestModelValidator(offCapabilityRepository.Object);
			await validator.ValidateCreateAsync(new ApiOffCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IOffCapabilityRepository> offCapabilityRepository = new Mock<IOffCapabilityRepository>();
			offCapabilityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new OffCapability()));

			var validator = new ApiOffCapabilityServerRequestModelValidator(offCapabilityRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOffCapabilityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>bdb10c6f3af18cc6ccf8c8991d21a37d</Hash>
</Codenesium>*/