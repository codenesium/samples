using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
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

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Person")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPersonServerRequestModelValidatorTest
	{
		public ApiPersonServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void FirstName_Create_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Update_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Create_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Update_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void Phone_Create_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 33));
		}

		[Fact]
		public async void Phone_Update_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 33));
		}

		[Fact]
		public async void Ssn_Create_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Ssn, new string('A', 13));
		}

		[Fact]
		public async void Ssn_Update_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Ssn, new string('A', 13));
		}
	}
}

/*<Codenesium>
    <Hash>b7ab3971e4b762b23f57fe7c348d0002</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/