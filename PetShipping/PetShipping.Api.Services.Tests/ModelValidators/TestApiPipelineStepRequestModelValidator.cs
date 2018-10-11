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
	[Trait("Table", "PipelineStep")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPipelineStepRequestModelValidatorTest
	{
		public ApiPipelineStepRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
			pipelineStepRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStep()));

			var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStepRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
			pipelineStepRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStep()));

			var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
			pipelineStepRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStep()));

			var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStepRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
			pipelineStepRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PipelineStep()));

			var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		// table.Columns[i].GetReferenceTable().AppTableName= PipelineStepStatu
		[Fact]
		public async void PipelineStepStatusId_Create_Valid_Reference()
		{
			Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
			pipelineStepRepository.Setup(x => x.PipelineStepStatuByPipelineStepStatusId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStepStatu>(new PipelineStepStatu()));

			var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStepRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepStatusId, 1);
		}

		[Fact]
		public async void PipelineStepStatusId_Create_Invalid_Reference()
		{
			Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
			pipelineStepRepository.Setup(x => x.PipelineStepStatuByPipelineStepStatusId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStepStatu>(null));

			var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);

			await validator.ValidateCreateAsync(new ApiPipelineStepRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStepStatusId, 1);
		}

		[Fact]
		public async void PipelineStepStatusId_Update_Valid_Reference()
		{
			Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
			pipelineStepRepository.Setup(x => x.PipelineStepStatuByPipelineStepStatusId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStepStatu>(new PipelineStepStatu()));

			var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PipelineStepStatusId, 1);
		}

		[Fact]
		public async void PipelineStepStatusId_Update_Invalid_Reference()
		{
			Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
			pipelineStepRepository.Setup(x => x.PipelineStepStatuByPipelineStepStatusId(It.IsAny<int>())).Returns(Task.FromResult<PipelineStepStatu>(null));

			var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PipelineStepStatusId, 1);
		}

		// table.Columns[i].GetReferenceTable().AppTableName= Employee
		[Fact]
		public async void ShipperId_Create_Valid_Reference()
		{
			Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
			pipelineStepRepository.Setup(x => x.EmployeeByShipperId(It.IsAny<int>())).Returns(Task.FromResult<Employee>(new Employee()));

			var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);
			await validator.ValidateCreateAsync(new ApiPipelineStepRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ShipperId, 1);
		}

		[Fact]
		public async void ShipperId_Create_Invalid_Reference()
		{
			Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
			pipelineStepRepository.Setup(x => x.EmployeeByShipperId(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));

			var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);

			await validator.ValidateCreateAsync(new ApiPipelineStepRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ShipperId, 1);
		}

		[Fact]
		public async void ShipperId_Update_Valid_Reference()
		{
			Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
			pipelineStepRepository.Setup(x => x.EmployeeByShipperId(It.IsAny<int>())).Returns(Task.FromResult<Employee>(new Employee()));

			var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ShipperId, 1);
		}

		[Fact]
		public async void ShipperId_Update_Invalid_Reference()
		{
			Mock<IPipelineStepRepository> pipelineStepRepository = new Mock<IPipelineStepRepository>();
			pipelineStepRepository.Setup(x => x.EmployeeByShipperId(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));

			var validator = new ApiPipelineStepRequestModelValidator(pipelineStepRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPipelineStepRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ShipperId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>c1819dd8acd08df7b7b707a71193c956</Hash>
</Codenesium>*/