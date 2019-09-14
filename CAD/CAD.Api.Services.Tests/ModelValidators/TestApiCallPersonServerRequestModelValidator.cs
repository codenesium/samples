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
	[Trait("Table", "CallPerson")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCallPersonServerRequestModelValidatorTest
	{
		public ApiCallPersonServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Note_Create_length()
		{
			Mock<ICallPersonRepository> callPersonRepository = new Mock<ICallPersonRepository>();
			callPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallPerson()));

			var validator = new ApiCallPersonServerRequestModelValidator(callPersonRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Note, new string('A', 8001));
		}

		[Fact]
		public async void Note_Update_length()
		{
			Mock<ICallPersonRepository> callPersonRepository = new Mock<ICallPersonRepository>();
			callPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CallPerson()));

			var validator = new ApiCallPersonServerRequestModelValidator(callPersonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Note, new string('A', 8001));
		}

		[Fact]
		public async void PersonId_Create_Valid_Reference()
		{
			Mock<ICallPersonRepository> callPersonRepository = new Mock<ICallPersonRepository>();
			callPersonRepository.Setup(x => x.PersonByPersonId(It.IsAny<int>())).Returns(Task.FromResult<Person>(new Person()));

			var validator = new ApiCallPersonServerRequestModelValidator(callPersonRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallPersonServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PersonId, 1);
		}

		[Fact]
		public async void PersonId_Create_Invalid_Reference()
		{
			Mock<ICallPersonRepository> callPersonRepository = new Mock<ICallPersonRepository>();
			callPersonRepository.Setup(x => x.PersonByPersonId(It.IsAny<int>())).Returns(Task.FromResult<Person>(null));

			var validator = new ApiCallPersonServerRequestModelValidator(callPersonRepository.Object);

			await validator.ValidateCreateAsync(new ApiCallPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonId, 1);
		}

		[Fact]
		public async void PersonId_Update_Valid_Reference()
		{
			Mock<ICallPersonRepository> callPersonRepository = new Mock<ICallPersonRepository>();
			callPersonRepository.Setup(x => x.PersonByPersonId(It.IsAny<int>())).Returns(Task.FromResult<Person>(new Person()));

			var validator = new ApiCallPersonServerRequestModelValidator(callPersonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallPersonServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PersonId, 1);
		}

		[Fact]
		public async void PersonId_Update_Invalid_Reference()
		{
			Mock<ICallPersonRepository> callPersonRepository = new Mock<ICallPersonRepository>();
			callPersonRepository.Setup(x => x.PersonByPersonId(It.IsAny<int>())).Returns(Task.FromResult<Person>(null));

			var validator = new ApiCallPersonServerRequestModelValidator(callPersonRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCallPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonId, 1);
		}

		[Fact]
		public async void PersonTypeId_Create_Valid_Reference()
		{
			Mock<ICallPersonRepository> callPersonRepository = new Mock<ICallPersonRepository>();
			callPersonRepository.Setup(x => x.PersonTypeByPersonTypeId(It.IsAny<int>())).Returns(Task.FromResult<PersonType>(new PersonType()));

			var validator = new ApiCallPersonServerRequestModelValidator(callPersonRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallPersonServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PersonTypeId, 1);
		}

		[Fact]
		public async void PersonTypeId_Create_Invalid_Reference()
		{
			Mock<ICallPersonRepository> callPersonRepository = new Mock<ICallPersonRepository>();
			callPersonRepository.Setup(x => x.PersonTypeByPersonTypeId(It.IsAny<int>())).Returns(Task.FromResult<PersonType>(null));

			var validator = new ApiCallPersonServerRequestModelValidator(callPersonRepository.Object);

			await validator.ValidateCreateAsync(new ApiCallPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonTypeId, 1);
		}

		[Fact]
		public async void PersonTypeId_Update_Valid_Reference()
		{
			Mock<ICallPersonRepository> callPersonRepository = new Mock<ICallPersonRepository>();
			callPersonRepository.Setup(x => x.PersonTypeByPersonTypeId(It.IsAny<int>())).Returns(Task.FromResult<PersonType>(new PersonType()));

			var validator = new ApiCallPersonServerRequestModelValidator(callPersonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallPersonServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PersonTypeId, 1);
		}

		[Fact]
		public async void PersonTypeId_Update_Invalid_Reference()
		{
			Mock<ICallPersonRepository> callPersonRepository = new Mock<ICallPersonRepository>();
			callPersonRepository.Setup(x => x.PersonTypeByPersonTypeId(It.IsAny<int>())).Returns(Task.FromResult<PersonType>(null));

			var validator = new ApiCallPersonServerRequestModelValidator(callPersonRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCallPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonTypeId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>01e2c2ab5a584be40482121dff84b9da</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/