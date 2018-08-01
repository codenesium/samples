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
	public partial class ApiHandlerRequestModelValidatorTest
	{
		public ApiHandlerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Email_Create_length()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateCreateAsync(new ApiHandlerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void Email_Update_length()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiHandlerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Create_length()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateCreateAsync(new ApiHandlerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Update_length()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiHandlerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Create_length()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateCreateAsync(new ApiHandlerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Update_length()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiHandlerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void Phone_Create_length()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateCreateAsync(new ApiHandlerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 11));
		}

		[Fact]
		public async void Phone_Update_length()
		{
			Mock<IHandlerRepository> handlerRepository = new Mock<IHandlerRepository>();
			handlerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Handler()));

			var validator = new ApiHandlerRequestModelValidator(handlerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiHandlerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 11));
		}
	}
}

/*<Codenesium>
    <Hash>c188d2a6767ecb7862d312e71b773505</Hash>
</Codenesium>*/