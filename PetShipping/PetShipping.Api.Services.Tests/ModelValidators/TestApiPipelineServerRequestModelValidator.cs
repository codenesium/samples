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
	public partial class ApiPipelineServerRequestModelValidatorTest
	{
		public ApiPipelineServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void PipelineStatusId_Create_Valid_Reference()
		{
			Mock<IPipelineRepository> pipelineRepository = new Mock<IPipelineRepository>();
			pipelineRepository.Setup(x => x.PipelineStatusByPipelineStatusId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStatus>(new PipelineStatus()));

			var validator = new ApiPipelineServerRequestModelValidator(pipelineRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStatusId, 1);
		}

		[Fact]
		public async void PipelineStatusId_Create_Invalid_Reference()
		{
			Mock<IPipelineRepository> pipelineRepository = new Mock<IPipelineRepository>();
			pipelineRepository.Setup(x => x.PipelineStatusByPipelineStatusId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStatus>(null));

			var validator = new ApiPipelineServerRequestModelValidator(pipelineRepository.Object);

			await validator.ValidateCreateAsync(new ApiPipelineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStatusId, 1);
		}

		[Fact]
		public async void PipelineStatusId_Update_Valid_Reference()
		{
			Mock<IPipelineRepository> pipelineRepository = new Mock<IPipelineRepository>();
			pipelineRepository.Setup(x => x.PipelineStatusByPipelineStatusId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStatus>(new PipelineStatus()));

			var validator = new ApiPipelineServerRequestModelValidator(pipelineRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStatusId, 1);
		}

		[Fact]
		public async void PipelineStatusId_Update_Invalid_Reference()
		{
			Mock<IPipelineRepository> pipelineRepository = new Mock<IPipelineRepository>();
			pipelineRepository.Setup(x => x.PipelineStatusByPipelineStatusId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStatus>(null));

			var validator = new ApiPipelineServerRequestModelValidator(pipelineRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPipelineServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStatusId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>4f864b25fd9aaa10def6486c79990fca</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/