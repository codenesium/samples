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
	public partial class ApiPipelineStatuServerRequestModelValidatorTest
	{
		public ApiPipelineStatuServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IPipelineStatuRepository> pipelineStatuRepository = new Mock<IPipelineStatuRepository>();
			pipelineStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStatu()));

			var validator = new ApiPipelineStatuServerRequestModelValidator(pipelineStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IPipelineStatuRepository> pipelineStatuRepository = new Mock<IPipelineStatuRepository>();
			pipelineStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStatu()));

			var validator = new ApiPipelineStatuServerRequestModelValidator(pipelineStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IPipelineStatuRepository> pipelineStatuRepository = new Mock<IPipelineStatuRepository>();
			pipelineStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStatu()));

			var validator = new ApiPipelineStatuServerRequestModelValidator(pipelineStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IPipelineStatuRepository> pipelineStatuRepository = new Mock<IPipelineStatuRepository>();
			pipelineStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStatu()));

			var validator = new ApiPipelineStatuServerRequestModelValidator(pipelineStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>6fe813cf0919d8e1a1f64c1dc4619bec</Hash>
</Codenesium>*/