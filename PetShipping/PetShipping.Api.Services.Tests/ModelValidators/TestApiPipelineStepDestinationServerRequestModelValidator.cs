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
	[Trait("Table", "PipelineStepDestination")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPipelineStepDestinationServerRequestModelValidatorTest
	{
		public ApiPipelineStepDestinationServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void DestinationId_Create_Valid_Reference()
		{
			Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
			pipelineStepDestinationRepository.Setup(x => x.DestinationByDestinationId(It.IsAny<int>())).Returns(Task.FromResult<Destination>(new Destination()));

			var validator = new ApiPipelineStepDestinationServerRequestModelValidator(pipelineStepDestinationRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStepDestinationServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.DestinationId, 1);
		}

		[Fact]
		public async void DestinationId_Create_Invalid_Reference()
		{
			Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
			pipelineStepDestinationRepository.Setup(x => x.DestinationByDestinationId(It.IsAny<int>())).Returns(Task.FromResult<Destination>(null));

			var validator = new ApiPipelineStepDestinationServerRequestModelValidator(pipelineStepDestinationRepository.Object);

			await validator.ValidateCreateAsync(new ApiPipelineStepDestinationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DestinationId, 1);
		}

		[Fact]
		public async void DestinationId_Update_Valid_Reference()
		{
			Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
			pipelineStepDestinationRepository.Setup(x => x.DestinationByDestinationId(It.IsAny<int>())).Returns(Task.FromResult<Destination>(new Destination()));

			var validator = new ApiPipelineStepDestinationServerRequestModelValidator(pipelineStepDestinationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepDestinationServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.DestinationId, 1);
		}

		[Fact]
		public async void DestinationId_Update_Invalid_Reference()
		{
			Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
			pipelineStepDestinationRepository.Setup(x => x.DestinationByDestinationId(It.IsAny<int>())).Returns(Task.FromResult<Destination>(null));

			var validator = new ApiPipelineStepDestinationServerRequestModelValidator(pipelineStepDestinationRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepDestinationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DestinationId, 1);
		}

		[Fact]
		public async void PipelineStepId_Create_Valid_Reference()
		{
			Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
			pipelineStepDestinationRepository.Setup(x => x.PipelineStepByPipelineStepId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

			var validator = new ApiPipelineStepDestinationServerRequestModelValidator(pipelineStepDestinationRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStepDestinationServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Create_Invalid_Reference()
		{
			Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
			pipelineStepDestinationRepository.Setup(x => x.PipelineStepByPipelineStepId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

			var validator = new ApiPipelineStepDestinationServerRequestModelValidator(pipelineStepDestinationRepository.Object);

			await validator.ValidateCreateAsync(new ApiPipelineStepDestinationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Update_Valid_Reference()
		{
			Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
			pipelineStepDestinationRepository.Setup(x => x.PipelineStepByPipelineStepId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

			var validator = new ApiPipelineStepDestinationServerRequestModelValidator(pipelineStepDestinationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepDestinationServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Update_Invalid_Reference()
		{
			Mock<IPipelineStepDestinationRepository> pipelineStepDestinationRepository = new Mock<IPipelineStepDestinationRepository>();
			pipelineStepDestinationRepository.Setup(x => x.PipelineStepByPipelineStepId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

			var validator = new ApiPipelineStepDestinationServerRequestModelValidator(pipelineStepDestinationRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepDestinationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>4de71577b9ee31f0cfccc82c7443419e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/