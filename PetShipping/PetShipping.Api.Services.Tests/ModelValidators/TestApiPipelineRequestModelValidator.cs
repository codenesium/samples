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
	[Trait("Table", "Pipeline")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPipelineRequestModelValidatorTest
	{
		public ApiPipelineRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void PipelineStatusId_Create_Valid_Reference()
		{
			Mock<IPipelineRepository> pipelineRepository = new Mock<IPipelineRepository>();
			pipelineRepository.Setup(x => x.GetPipelineStatu(It.IsAny<int>())).Returns(Task.FromResult<PipelineStatu>(new PipelineStatu()));

			var validator = new ApiPipelineRequestModelValidator(pipelineRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStatusId, 1);
		}

		[Fact]
		public async void PipelineStatusId_Create_Invalid_Reference()
		{
			Mock<IPipelineRepository> pipelineRepository = new Mock<IPipelineRepository>();
			pipelineRepository.Setup(x => x.GetPipelineStatu(It.IsAny<int>())).Returns(Task.FromResult<PipelineStatu>(null));

			var validator = new ApiPipelineRequestModelValidator(pipelineRepository.Object);

			await validator.ValidateCreateAsync(new ApiPipelineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStatusId, 1);
		}

		[Fact]
		public async void PipelineStatusId_Update_Valid_Reference()
		{
			Mock<IPipelineRepository> pipelineRepository = new Mock<IPipelineRepository>();
			pipelineRepository.Setup(x => x.GetPipelineStatu(It.IsAny<int>())).Returns(Task.FromResult<PipelineStatu>(new PipelineStatu()));

			var validator = new ApiPipelineRequestModelValidator(pipelineRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStatusId, 1);
		}

		[Fact]
		public async void PipelineStatusId_Update_Invalid_Reference()
		{
			Mock<IPipelineRepository> pipelineRepository = new Mock<IPipelineRepository>();
			pipelineRepository.Setup(x => x.GetPipelineStatu(It.IsAny<int>())).Returns(Task.FromResult<PipelineStatu>(null));

			var validator = new ApiPipelineRequestModelValidator(pipelineRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPipelineRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStatusId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>d027e152cab7c9342fc9138df52503d6</Hash>
</Codenesium>*/