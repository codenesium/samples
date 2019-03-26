using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "JobCandidate")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiJobCandidateServerRequestModelValidatorTest
	{
		public ApiJobCandidateServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void BusinessEntityID_Create_Valid_Reference()
		{
			Mock<IJobCandidateRepository> jobCandidateRepository = new Mock<IJobCandidateRepository>();
			jobCandidateRepository.Setup(x => x.EmployeeByBusinessEntityID(It.IsAny<int>())).Returns(Task.FromResult<Employee>(new Employee()));

			var validator = new ApiJobCandidateServerRequestModelValidator(jobCandidateRepository.Object);
			await validator.ValidateCreateAsync(new ApiJobCandidateServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.BusinessEntityID, 1);
		}

		[Fact]
		public async void BusinessEntityID_Create_Invalid_Reference()
		{
			Mock<IJobCandidateRepository> jobCandidateRepository = new Mock<IJobCandidateRepository>();
			jobCandidateRepository.Setup(x => x.EmployeeByBusinessEntityID(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));

			var validator = new ApiJobCandidateServerRequestModelValidator(jobCandidateRepository.Object);

			await validator.ValidateCreateAsync(new ApiJobCandidateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.BusinessEntityID, 1);
		}

		[Fact]
		public async void BusinessEntityID_Update_Valid_Reference()
		{
			Mock<IJobCandidateRepository> jobCandidateRepository = new Mock<IJobCandidateRepository>();
			jobCandidateRepository.Setup(x => x.EmployeeByBusinessEntityID(It.IsAny<int>())).Returns(Task.FromResult<Employee>(new Employee()));

			var validator = new ApiJobCandidateServerRequestModelValidator(jobCandidateRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiJobCandidateServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.BusinessEntityID, 1);
		}

		[Fact]
		public async void BusinessEntityID_Update_Invalid_Reference()
		{
			Mock<IJobCandidateRepository> jobCandidateRepository = new Mock<IJobCandidateRepository>();
			jobCandidateRepository.Setup(x => x.EmployeeByBusinessEntityID(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));

			var validator = new ApiJobCandidateServerRequestModelValidator(jobCandidateRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiJobCandidateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.BusinessEntityID, 1);
		}
	}
}

/*<Codenesium>
    <Hash>3170300a7519adbabc6bb44a0d528c9e</Hash>
</Codenesium>*/