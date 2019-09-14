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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Customer")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCustomerServerRequestModelValidatorTest
	{
		public ApiCustomerServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Email_Create_null()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateCreateAsync(new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Update_null()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Create_length()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateCreateAsync(new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void Email_Update_length()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Create_null()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateCreateAsync(new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Update_null()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Create_length()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateCreateAsync(new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Update_length()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Create_null()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateCreateAsync(new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Update_null()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Create_length()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateCreateAsync(new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Update_length()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void Phone_Create_null()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateCreateAsync(new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
		}

		[Fact]
		public async void Phone_Update_null()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
		}

		[Fact]
		public async void Phone_Create_length()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateCreateAsync(new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}

		[Fact]
		public async void Phone_Update_length()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>527c293abe950a22c1c52124e769844a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/