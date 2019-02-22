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
	[Trait("Table", "CallType")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCallTypeServerRequestModelValidatorTest
	{
		public ApiCallTypeServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ICallTypeRepository> callTypeRepository = new Mock<ICallTypeRepository>();
			callTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallType()));

			var validator = new ApiCallTypeServerRequestModelValidator(callTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ICallTypeRepository> callTypeRepository = new Mock<ICallTypeRepository>();
			callTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallType()));

			var validator = new ApiCallTypeServerRequestModelValidator(callTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ICallTypeRepository> callTypeRepository = new Mock<ICallTypeRepository>();
			callTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallType()));

			var validator = new ApiCallTypeServerRequestModelValidator(callTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ICallTypeRepository> callTypeRepository = new Mock<ICallTypeRepository>();
			callTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallType()));

			var validator = new ApiCallTypeServerRequestModelValidator(callTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>56084a433c41754f5e0eb33415573ae6</Hash>
</Codenesium>*/