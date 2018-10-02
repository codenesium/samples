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
	[Trait("Table", "PipelineStatu")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPipelineStatuRequestModelValidatorTest
	{
		public ApiPipelineStatuRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IPipelineStatuRepository> pipelineStatuRepository = new Mock<IPipelineStatuRepository>();
			pipelineStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStatu()));

			var validator = new ApiPipelineStatuRequestModelValidator(pipelineStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IPipelineStatuRepository> pipelineStatuRepository = new Mock<IPipelineStatuRepository>();
			pipelineStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStatu()));

			var validator = new ApiPipelineStatuRequestModelValidator(pipelineStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IPipelineStatuRepository> pipelineStatuRepository = new Mock<IPipelineStatuRepository>();
			pipelineStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStatu()));

			var validator = new ApiPipelineStatuRequestModelValidator(pipelineStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IPipelineStatuRepository> pipelineStatuRepository = new Mock<IPipelineStatuRepository>();
			pipelineStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStatu()));

			var validator = new ApiPipelineStatuRequestModelValidator(pipelineStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>94e1fd14864c0ff356d5f62bab571082</Hash>
</Codenesium>*/