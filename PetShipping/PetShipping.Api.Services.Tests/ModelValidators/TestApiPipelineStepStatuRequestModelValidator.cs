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
	public partial class ApiPipelineStepStatuRequestModelValidatorTest
	{
		public ApiPipelineStepStatuRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IPipelineStepStatuRepository> pipelineStepStatuRepository = new Mock<IPipelineStepStatuRepository>();
			pipelineStepStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatu()));

			var validator = new ApiPipelineStepStatuRequestModelValidator(pipelineStepStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStepStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IPipelineStepStatuRepository> pipelineStepStatuRepository = new Mock<IPipelineStepStatuRepository>();
			pipelineStepStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatu()));

			var validator = new ApiPipelineStepStatuRequestModelValidator(pipelineStepStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IPipelineStepStatuRepository> pipelineStepStatuRepository = new Mock<IPipelineStepStatuRepository>();
			pipelineStepStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatu()));

			var validator = new ApiPipelineStepStatuRequestModelValidator(pipelineStepStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStepStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IPipelineStepStatuRepository> pipelineStepStatuRepository = new Mock<IPipelineStepStatuRepository>();
			pipelineStepStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStepStatu()));

			var validator = new ApiPipelineStepStatuRequestModelValidator(pipelineStepStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>ef326c1e8caa346328cfdc43db1e9b70</Hash>
</Codenesium>*/