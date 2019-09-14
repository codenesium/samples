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
	[Trait("Table", "HandlerPipelineStep")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiHandlerPipelineStepServerRequestModelValidatorTest
	{
		public ApiHandlerPipelineStepServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void HandlerId_Create_Valid_Reference()
		{
			Mock<IHandlerPipelineStepRepository> handlerPipelineStepRepository = new Mock<IHandlerPipelineStepRepository>();
			handlerPipelineStepRepository.Setup(x => x.HandlerByHandlerId(It.IsAny<int>())).Returns(Task.FromResult<Handler>(new Handler()));

			var validator = new ApiHandlerPipelineStepServerRequestModelValidator(handlerPipelineStepRepository.Object);
			await validator.ValidateCreateAsync(new ApiHandlerPipelineStepServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.HandlerId, 1);
		}

		[Fact]
		public async void HandlerId_Create_Invalid_Reference()
		{
			Mock<IHandlerPipelineStepRepository> handlerPipelineStepRepository = new Mock<IHandlerPipelineStepRepository>();
			handlerPipelineStepRepository.Setup(x => x.HandlerByHandlerId(It.IsAny<int>())).Returns(Task.FromResult<Handler>(null));

			var validator = new ApiHandlerPipelineStepServerRequestModelValidator(handlerPipelineStepRepository.Object);

			await validator.ValidateCreateAsync(new ApiHandlerPipelineStepServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.HandlerId, 1);
		}

		[Fact]
		public async void HandlerId_Update_Valid_Reference()
		{
			Mock<IHandlerPipelineStepRepository> handlerPipelineStepRepository = new Mock<IHandlerPipelineStepRepository>();
			handlerPipelineStepRepository.Setup(x => x.HandlerByHandlerId(It.IsAny<int>())).Returns(Task.FromResult<Handler>(new Handler()));

			var validator = new ApiHandlerPipelineStepServerRequestModelValidator(handlerPipelineStepRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiHandlerPipelineStepServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.HandlerId, 1);
		}

		[Fact]
		public async void HandlerId_Update_Invalid_Reference()
		{
			Mock<IHandlerPipelineStepRepository> handlerPipelineStepRepository = new Mock<IHandlerPipelineStepRepository>();
			handlerPipelineStepRepository.Setup(x => x.HandlerByHandlerId(It.IsAny<int>())).Returns(Task.FromResult<Handler>(null));

			var validator = new ApiHandlerPipelineStepServerRequestModelValidator(handlerPipelineStepRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiHandlerPipelineStepServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.HandlerId, 1);
		}

		[Fact]
		public async void PipelineStepId_Create_Valid_Reference()
		{
			Mock<IHandlerPipelineStepRepository> handlerPipelineStepRepository = new Mock<IHandlerPipelineStepRepository>();
			handlerPipelineStepRepository.Setup(x => x.PipelineStepByPipelineStepId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

			var validator = new ApiHandlerPipelineStepServerRequestModelValidator(handlerPipelineStepRepository.Object);
			await validator.ValidateCreateAsync(new ApiHandlerPipelineStepServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Create_Invalid_Reference()
		{
			Mock<IHandlerPipelineStepRepository> handlerPipelineStepRepository = new Mock<IHandlerPipelineStepRepository>();
			handlerPipelineStepRepository.Setup(x => x.PipelineStepByPipelineStepId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

			var validator = new ApiHandlerPipelineStepServerRequestModelValidator(handlerPipelineStepRepository.Object);

			await validator.ValidateCreateAsync(new ApiHandlerPipelineStepServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Update_Valid_Reference()
		{
			Mock<IHandlerPipelineStepRepository> handlerPipelineStepRepository = new Mock<IHandlerPipelineStepRepository>();
			handlerPipelineStepRepository.Setup(x => x.PipelineStepByPipelineStepId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

			var validator = new ApiHandlerPipelineStepServerRequestModelValidator(handlerPipelineStepRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiHandlerPipelineStepServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Update_Invalid_Reference()
		{
			Mock<IHandlerPipelineStepRepository> handlerPipelineStepRepository = new Mock<IHandlerPipelineStepRepository>();
			handlerPipelineStepRepository.Setup(x => x.PipelineStepByPipelineStepId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

			var validator = new ApiHandlerPipelineStepServerRequestModelValidator(handlerPipelineStepRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiHandlerPipelineStepServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>84ab5e14ece8747c620ce8e82b821eb9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/