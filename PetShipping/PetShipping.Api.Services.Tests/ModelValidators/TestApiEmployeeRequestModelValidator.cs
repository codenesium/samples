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
	[Trait("Table", "Employee")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiEmployeeRequestModelValidatorTest
	{
		public ApiEmployeeRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void FirstName_Create_length()
		{
			Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
			employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

			var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
			await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Update_length()
		{
			Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
			employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

			var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEmployeeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Create_length()
		{
			Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
			employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

			var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
			await validator.ValidateCreateAsync(new ApiEmployeeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Update_length()
		{
			Mock<IEmployeeRepository> employeeRepository = new Mock<IEmployeeRepository>();
			employeeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Employee()));

			var validator = new ApiEmployeeRequestModelValidator(employeeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEmployeeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>983d7c5a0f146442ae31c5b46882779d</Hash>
</Codenesium>*/