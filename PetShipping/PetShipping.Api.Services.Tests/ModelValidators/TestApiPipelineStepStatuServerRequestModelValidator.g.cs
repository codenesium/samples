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
	[Trait("Table", "PipelineStepStatu")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPipelineStepStatuServerRequestModelValidatorTest
	{
		public ApiPipelineStepStatuServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IPipelineStepStatuRepository> pipelineStepStatuRepository = new Mock<IPipelineStepStatuRepository>();
			pipelineStepStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatu()));

			var validator = new ApiPipelineStepStatuServerRequestModelValidator(pipelineStepStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStepStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IPipelineStepStatuRepository> pipelineStepStatuRepository = new Mock<IPipelineStepStatuRepository>();
			pipelineStepStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatu()));

			var validator = new ApiPipelineStepStatuServerRequestModelValidator(pipelineStepStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IPipelineStepStatuRepository> pipelineStepStatuRepository = new Mock<IPipelineStepStatuRepository>();
			pipelineStepStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatu()));

			var validator = new ApiPipelineStepStatuServerRequestModelValidator(pipelineStepStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStepStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IPipelineStepStatuRepository> pipelineStepStatuRepository = new Mock<IPipelineStepStatuRepository>();
			pipelineStepStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatu()));

			var validator = new ApiPipelineStepStatuServerRequestModelValidator(pipelineStepStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>8d70df3386ec7f15c8edb2738e92b55f</Hash>
</Codenesium>*/