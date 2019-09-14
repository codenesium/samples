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
	[Trait("Table", "Handler")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiHandlerServerRequestModelValidatorTest
	{
		public ApiHandlerServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Email_Create_null()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerServerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateCreateAsync(new ApiHandlerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Update_null()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerServerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiHandlerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Create_length()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerServerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateCreateAsync(new ApiHandlerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void Email_Update_length()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerServerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiHandlerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Create_null()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerServerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateCreateAsync(new ApiHandlerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Update_null()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerServerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiHandlerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Create_length()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerServerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateCreateAsync(new ApiHandlerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Update_length()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerServerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiHandlerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Create_null()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerServerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateCreateAsync(new ApiHandlerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Update_null()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerServerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiHandlerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Create_length()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerServerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateCreateAsync(new ApiHandlerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Update_length()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerServerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiHandlerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void Phone_Create_null()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerServerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateCreateAsync(new ApiHandlerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
		}

		[Fact]
		public async void Phone_Update_null()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerServerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiHandlerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
		}

		[Fact]
		public async void Phone_Create_length()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerServerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateCreateAsync(new ApiHandlerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 11));
		}

		[Fact]
		public async void Phone_Update_length()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerServerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiHandlerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 11));
		}
	}
}

/*<Codenesium>
    <Hash>f5e6f5affa092c55ebcae45ed5cd6162</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/