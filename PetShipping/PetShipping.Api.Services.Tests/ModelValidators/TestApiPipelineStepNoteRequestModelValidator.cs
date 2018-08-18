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
	[Trait("Table", "PipelineStepNote")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPipelineStepNoteRequestModelValidatorTest
	{
		public ApiPipelineStepNoteRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void EmployeeId_Create_Valid_Reference()
		{
			Mock<IPipelineStepNoteRepository> pipelineStepNoteRepository = new Mock<IPipelineStepNoteRepository>();
			pipelineStepNoteRepository.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(Task.FromResult<Employee>(new Employee()));

			var validator = new ApiPipelineStepNoteRequestModelValidator(pipelineStepNoteRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStepNoteRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeId, 1);
		}

		[Fact]
		public async void EmployeeId_Create_Invalid_Reference()
		{
			Mock<IPipelineStepNoteRepository> pipelineStepNoteRepository = new Mock<IPipelineStepNoteRepository>();
			pipelineStepNoteRepository.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));

			var validator = new ApiPipelineStepNoteRequestModelValidator(pipelineStepNoteRepository.Object);

			await validator.ValidateCreateAsync(new ApiPipelineStepNoteRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmployeeId, 1);
		}

		[Fact]
		public async void EmployeeId_Update_Valid_Reference()
		{
			Mock<IPipelineStepNoteRepository> pipelineStepNoteRepository = new Mock<IPipelineStepNoteRepository>();
			pipelineStepNoteRepository.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(Task.FromResult<Employee>(new Employee()));

			var validator = new ApiPipelineStepNoteRequestModelValidator(pipelineStepNoteRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepNoteRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeId, 1);
		}

		[Fact]
		public async void EmployeeId_Update_Invalid_Reference()
		{
			Mock<IPipelineStepNoteRepository> pipelineStepNoteRepository = new Mock<IPipelineStepNoteRepository>();
			pipelineStepNoteRepository.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));

			var validator = new ApiPipelineStepNoteRequestModelValidator(pipelineStepNoteRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepNoteRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmployeeId, 1);
		}

		[Fact]
		public async void PipelineStepId_Create_Valid_Reference()
		{
			Mock<IPipelineStepNoteRepository> pipelineStepNoteRepository = new Mock<IPipelineStepNoteRepository>();
			pipelineStepNoteRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

			var validator = new ApiPipelineStepNoteRequestModelValidator(pipelineStepNoteRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStepNoteRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Create_Invalid_Reference()
		{
			Mock<IPipelineStepNoteRepository> pipelineStepNoteRepository = new Mock<IPipelineStepNoteRepository>();
			pipelineStepNoteRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

			var validator = new ApiPipelineStepNoteRequestModelValidator(pipelineStepNoteRepository.Object);

			await validator.ValidateCreateAsync(new ApiPipelineStepNoteRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Update_Valid_Reference()
		{
			Mock<IPipelineStepNoteRepository> pipelineStepNoteRepository = new Mock<IPipelineStepNoteRepository>();
			pipelineStepNoteRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(new PipelineStep()));

			var validator = new ApiPipelineStepNoteRequestModelValidator(pipelineStepNoteRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepNoteRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}

		[Fact]
		public async void PipelineStepId_Update_Invalid_Reference()
		{
			Mock<IPipelineStepNoteRepository> pipelineStepNoteRepository = new Mock<IPipelineStepNoteRepository>();
			pipelineStepNoteRepository.Setup(x => x.GetPipelineStep(It.IsAny<int>())).Returns(Task.FromResult<PipelineStep>(null));

			var validator = new ApiPipelineStepNoteRequestModelValidator(pipelineStepNoteRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepNoteRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStepId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>92078be125d13da20b0cfbd29943c8d1</Hash>
</Codenesium>*/