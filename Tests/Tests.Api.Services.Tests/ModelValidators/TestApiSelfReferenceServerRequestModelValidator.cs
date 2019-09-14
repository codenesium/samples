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
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SelfReference")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSelfReferenceServerRequestModelValidatorTest
	{
		public ApiSelfReferenceServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void SelfReferenceId_Create_Valid_Reference()
		{
			Mock<ISelfReferenceRepository> selfReferenceRepository = new Mock<ISelfReferenceRepository>();
			selfReferenceRepository.Setup(x => x.SelfReferenceBySelfReferenceId(It.IsAny<int>())).Returns(Task.FromResult<SelfReference>(new SelfReference()));

			var validator = new ApiSelfReferenceServerRequestModelValidator(selfReferenceRepository.Object);
			await validator.ValidateCreateAsync(new ApiSelfReferenceServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SelfReferenceId, 1);
		}

		[Fact]
		public async void SelfReferenceId_Create_Invalid_Reference()
		{
			Mock<ISelfReferenceRepository> selfReferenceRepository = new Mock<ISelfReferenceRepository>();
			selfReferenceRepository.Setup(x => x.SelfReferenceBySelfReferenceId(It.IsAny<int>())).Returns(Task.FromResult<SelfReference>(null));

			var validator = new ApiSelfReferenceServerRequestModelValidator(selfReferenceRepository.Object);

			await validator.ValidateCreateAsync(new ApiSelfReferenceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SelfReferenceId, 1);
		}

		[Fact]
		public async void SelfReferenceId_Update_Valid_Reference()
		{
			Mock<ISelfReferenceRepository> selfReferenceRepository = new Mock<ISelfReferenceRepository>();
			selfReferenceRepository.Setup(x => x.SelfReferenceBySelfReferenceId(It.IsAny<int>())).Returns(Task.FromResult<SelfReference>(new SelfReference()));

			var validator = new ApiSelfReferenceServerRequestModelValidator(selfReferenceRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSelfReferenceServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SelfReferenceId, 1);
		}

		[Fact]
		public async void SelfReferenceId_Update_Invalid_Reference()
		{
			Mock<ISelfReferenceRepository> selfReferenceRepository = new Mock<ISelfReferenceRepository>();
			selfReferenceRepository.Setup(x => x.SelfReferenceBySelfReferenceId(It.IsAny<int>())).Returns(Task.FromResult<SelfReference>(null));

			var validator = new ApiSelfReferenceServerRequestModelValidator(selfReferenceRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSelfReferenceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SelfReferenceId, 1);
		}

		[Fact]
		public async void SelfReferenceId2_Create_Valid_Reference()
		{
			Mock<ISelfReferenceRepository> selfReferenceRepository = new Mock<ISelfReferenceRepository>();
			selfReferenceRepository.Setup(x => x.SelfReferenceBySelfReferenceId2(It.IsAny<int>())).Returns(Task.FromResult<SelfReference>(new SelfReference()));

			var validator = new ApiSelfReferenceServerRequestModelValidator(selfReferenceRepository.Object);
			await validator.ValidateCreateAsync(new ApiSelfReferenceServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SelfReferenceId2, 1);
		}

		[Fact]
		public async void SelfReferenceId2_Create_Invalid_Reference()
		{
			Mock<ISelfReferenceRepository> selfReferenceRepository = new Mock<ISelfReferenceRepository>();
			selfReferenceRepository.Setup(x => x.SelfReferenceBySelfReferenceId2(It.IsAny<int>())).Returns(Task.FromResult<SelfReference>(null));

			var validator = new ApiSelfReferenceServerRequestModelValidator(selfReferenceRepository.Object);

			await validator.ValidateCreateAsync(new ApiSelfReferenceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SelfReferenceId2, 1);
		}

		[Fact]
		public async void SelfReferenceId2_Update_Valid_Reference()
		{
			Mock<ISelfReferenceRepository> selfReferenceRepository = new Mock<ISelfReferenceRepository>();
			selfReferenceRepository.Setup(x => x.SelfReferenceBySelfReferenceId2(It.IsAny<int>())).Returns(Task.FromResult<SelfReference>(new SelfReference()));

			var validator = new ApiSelfReferenceServerRequestModelValidator(selfReferenceRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSelfReferenceServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SelfReferenceId2, 1);
		}

		[Fact]
		public async void SelfReferenceId2_Update_Invalid_Reference()
		{
			Mock<ISelfReferenceRepository> selfReferenceRepository = new Mock<ISelfReferenceRepository>();
			selfReferenceRepository.Setup(x => x.SelfReferenceBySelfReferenceId2(It.IsAny<int>())).Returns(Task.FromResult<SelfReference>(null));

			var validator = new ApiSelfReferenceServerRequestModelValidator(selfReferenceRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSelfReferenceServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SelfReferenceId2, 1);
		}
	}
}

/*<Codenesium>
    <Hash>8d36dd6d35ca6d57c064c5703671a406</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/