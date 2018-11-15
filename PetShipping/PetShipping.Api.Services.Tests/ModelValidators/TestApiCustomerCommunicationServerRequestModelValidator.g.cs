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
	[Trait("Table", "CustomerCommunication")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCustomerCommunicationServerRequestModelValidatorTest
	{
		public ApiCustomerCommunicationServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void CustomerId_Create_Valid_Reference()
		{
			Mock<ICustomerCommunicationRepository> customerCommunicationRepository = new Mock<ICustomerCommunicationRepository>();
			customerCommunicationRepository.Setup(x => x.CustomerByCustomerId(It.IsAny<int>())).Returns(Task.FromResult<Customer>(new Customer()));

			var validator = new ApiCustomerCommunicationServerRequestModelValidator(customerCommunicationRepository.Object);
			await validator.ValidateCreateAsync(new ApiCustomerCommunicationServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CustomerId, 1);
		}

		[Fact]
		public async void CustomerId_Create_Invalid_Reference()
		{
			Mock<ICustomerCommunicationRepository> customerCommunicationRepository = new Mock<ICustomerCommunicationRepository>();
			customerCommunicationRepository.Setup(x => x.CustomerByCustomerId(It.IsAny<int>())).Returns(Task.FromResult<Customer>(null));

			var validator = new ApiCustomerCommunicationServerRequestModelValidator(customerCommunicationRepository.Object);

			await validator.ValidateCreateAsync(new ApiCustomerCommunicationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CustomerId, 1);
		}

		[Fact]
		public async void CustomerId_Update_Valid_Reference()
		{
			Mock<ICustomerCommunicationRepository> customerCommunicationRepository = new Mock<ICustomerCommunicationRepository>();
			customerCommunicationRepository.Setup(x => x.CustomerByCustomerId(It.IsAny<int>())).Returns(Task.FromResult<Customer>(new Customer()));

			var validator = new ApiCustomerCommunicationServerRequestModelValidator(customerCommunicationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCustomerCommunicationServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CustomerId, 1);
		}

		[Fact]
		public async void CustomerId_Update_Invalid_Reference()
		{
			Mock<ICustomerCommunicationRepository> customerCommunicationRepository = new Mock<ICustomerCommunicationRepository>();
			customerCommunicationRepository.Setup(x => x.CustomerByCustomerId(It.IsAny<int>())).Returns(Task.FromResult<Customer>(null));

			var validator = new ApiCustomerCommunicationServerRequestModelValidator(customerCommunicationRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCustomerCommunicationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CustomerId, 1);
		}

		[Fact]
		public async void EmployeeId_Create_Valid_Reference()
		{
			Mock<ICustomerCommunicationRepository> customerCommunicationRepository = new Mock<ICustomerCommunicationRepository>();
			customerCommunicationRepository.Setup(x => x.EmployeeByEmployeeId(It.IsAny<int>())).Returns(Task.FromResult<Employee>(new Employee()));

			var validator = new ApiCustomerCommunicationServerRequestModelValidator(customerCommunicationRepository.Object);
			await validator.ValidateCreateAsync(new ApiCustomerCommunicationServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeId, 1);
		}

		[Fact]
		public async void EmployeeId_Create_Invalid_Reference()
		{
			Mock<ICustomerCommunicationRepository> customerCommunicationRepository = new Mock<ICustomerCommunicationRepository>();
			customerCommunicationRepository.Setup(x => x.EmployeeByEmployeeId(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));

			var validator = new ApiCustomerCommunicationServerRequestModelValidator(customerCommunicationRepository.Object);

			await validator.ValidateCreateAsync(new ApiCustomerCommunicationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmployeeId, 1);
		}

		[Fact]
		public async void EmployeeId_Update_Valid_Reference()
		{
			Mock<ICustomerCommunicationRepository> customerCommunicationRepository = new Mock<ICustomerCommunicationRepository>();
			customerCommunicationRepository.Setup(x => x.EmployeeByEmployeeId(It.IsAny<int>())).Returns(Task.FromResult<Employee>(new Employee()));

			var validator = new ApiCustomerCommunicationServerRequestModelValidator(customerCommunicationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCustomerCommunicationServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeId, 1);
		}

		[Fact]
		public async void EmployeeId_Update_Invalid_Reference()
		{
			Mock<ICustomerCommunicationRepository> customerCommunicationRepository = new Mock<ICustomerCommunicationRepository>();
			customerCommunicationRepository.Setup(x => x.EmployeeByEmployeeId(It.IsAny<int>())).Returns(Task.FromResult<Employee>(null));

			var validator = new ApiCustomerCommunicationServerRequestModelValidator(customerCommunicationRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCustomerCommunicationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmployeeId, 1);
		}

		[Fact]
		public async void Note_Create_null()
		{
			Mock<ICustomerCommunicationRepository> customerCommunicationRepository = new Mock<ICustomerCommunicationRepository>();
			customerCommunicationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CustomerCommunication()));

			var validator = new ApiCustomerCommunicationServerRequestModelValidator(customerCommunicationRepository.Object);
			await validator.ValidateCreateAsync(new ApiCustomerCommunicationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Note, null as string);
		}

		[Fact]
		public async void Note_Update_null()
		{
			Mock<ICustomerCommunicationRepository> customerCommunicationRepository = new Mock<ICustomerCommunicationRepository>();
			customerCommunicationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CustomerCommunication()));

			var validator = new ApiCustomerCommunicationServerRequestModelValidator(customerCommunicationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCustomerCommunicationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Note, null as string);
		}
	}
}

/*<Codenesium>
    <Hash>6da51f8abce61b0a9a4cf80caa86e42d</Hash>
</Codenesium>*/