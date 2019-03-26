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
	[Trait("Table", "Person")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPersonServerRequestModelValidatorTest
	{
		public ApiPersonServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void FirstName_Create_null()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Update_null()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Create_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 51));
		}

		[Fact]
		public async void FirstName_Update_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 51));
		}

		[Fact]
		public async void LastName_Create_null()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Update_null()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Create_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 51));
		}

		[Fact]
		public async void LastName_Update_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 51));
		}

		[Fact]
		public async void MiddleName_Create_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.MiddleName, new string('A', 51));
		}

		[Fact]
		public async void MiddleName_Update_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.MiddleName, new string('A', 51));
		}

		[Fact]
		public async void PersonType_Create_null()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonType, null as string);
		}

		[Fact]
		public async void PersonType_Update_null()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonType, null as string);
		}

		[Fact]
		public async void PersonType_Create_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonType, new string('A', 3));
		}

		[Fact]
		public async void PersonType_Update_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonType, new string('A', 3));
		}

		[Fact]
		public async void Suffix_Create_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Suffix, new string('A', 11));
		}

		[Fact]
		public async void Suffix_Update_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Suffix, new string('A', 11));
		}

		[Fact]
		public async void Title_Create_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 9));
		}

		[Fact]
		public async void Title_Update_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 9));
		}

		[Fact]
		private async void BeUniqueByRowguid_Create_Exists()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<Person>(new Person()));
			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);

			await validator.ValidateCreateAsync(new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Create_Not_Exists()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<Person>(null));
			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);

			await validator.ValidateCreateAsync(new ApiPersonServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Update_Exists()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<Person>(new Person()));
			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Update_Not_Exists()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<Person>(null));
			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPersonServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>1437322e5258b5bd0f2438a301b2783e</Hash>
</Codenesium>*/