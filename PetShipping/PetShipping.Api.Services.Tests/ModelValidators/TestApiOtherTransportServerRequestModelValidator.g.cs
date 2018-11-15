using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "OtherTransport")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiOtherTransportServerRequestModelValidatorTest
	{
		public ApiOtherTransportServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void HandlerId_Create_Valid_Reference()
		{
			Mock<IOtherTransportRepository> otherTransportRepository = new Mock<IOtherTransportRepository>();
			otherTransportRepository.Setup(x => x.HandlerByHandlerId(It.IsAny<int>())).Returns(Task.FromResult<Handler>(new Handler()));

			var validator = new ApiOtherTransportServerRequestModelValidator(otherTransportRepository.Object);
			await validator.ValidateCreateAsync(new ApiOtherTransportServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.HandlerId, 1);
		}

		[Fact]
		public async void HandlerId_Create_Invalid_Reference()
		{
			Mock<IOtherTransportRepository> otherTransportRepository = new Mock<IOtherTransportRepository>();
			otherTransportRepository.Setup(x => x.HandlerByHandlerId(It.IsAny<int>())).Returns(Task.FromResult<Handler>(null));

			var validator = new ApiOtherTransportServerRequestModelValidator(otherTransportRepository.Object);

			await validator.ValidateCreateAsync(new ApiOtherTransportServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.HandlerId, 1);
		}

		[Fact]
		public async void HandlerId_Update_Valid_Reference()
		{
			Mock<IOtherTransportRepository> otherTransportRepository = new Mock<IOtherTransportRepository>();
			otherTransportRepository.Setup(x => x.HandlerByHandlerId(It.IsAny<int>())).Returns(Task.FromResult<Handler>(new Handler()));

			var validator = new ApiOtherTransportServerRequestModelValidator(otherTransportRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOtherTransportServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.HandlerId, 1);
		}

		[Fact]
		public async void HandlerId_Update_Invalid_Reference()
		{
			Mock<IOtherTransportRepository> otherTransportRepository = new Mock<IOtherTransportRepository>();
			otherTransportRepository.Setup(x => x.HandlerByHandlerId(It.IsAny<int>())).Returns(Task.FromResult<Handler>(null));

			var validator = new ApiOtherTransportServerRequestModelValidator(otherTransportRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiOtherTransportServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.HandlerId, 1);
		}

		[Fact]
		public async void PipelineStepId_Create_Valid_Reference()
		{
			Mock<IOtherTransportRepository> otherTransportRepository = new Mock<IOtherTransportRepository>();
			otherTransportRepository.Setup(x => x.PipelineStepByPipelineStepId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

			var validator = new ApiOtherTransportServerRequestModelValidator(otherTransportRepository.Object);
			await validator.ValidateCreateAsync(new ApiOtherTransportServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Create_Invalid_Reference()
		{
			Mock<IOtherTransportRepository> otherTransportRepository = new Mock<IOtherTransportRepository>();
			otherTransportRepository.Setup(x => x.PipelineStepByPipelineStepId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

			var validator = new ApiOtherTransportServerRequestModelValidator(otherTransportRepository.Object);

			await validator.ValidateCreateAsync(new ApiOtherTransportServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Update_Valid_Reference()
		{
			Mock<IOtherTransportRepository> otherTransportRepository = new Mock<IOtherTransportRepository>();
			otherTransportRepository.Setup(x => x.PipelineStepByPipelineStepId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

			var validator = new ApiOtherTransportServerRequestModelValidator(otherTransportRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOtherTransportServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Update_Invalid_Reference()
		{
			Mock<IOtherTransportRepository> otherTransportRepository = new Mock<IOtherTransportRepository>();
			otherTransportRepository.Setup(x => x.PipelineStepByPipelineStepId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

			var validator = new ApiOtherTransportServerRequestModelValidator(otherTransportRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiOtherTransportServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>326afed1027f9e0cdf3bd045dc43ae90</Hash>
</Codenesium>*/