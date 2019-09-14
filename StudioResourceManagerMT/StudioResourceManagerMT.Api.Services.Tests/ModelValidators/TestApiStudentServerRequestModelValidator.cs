using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Student")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiStudentServerRequestModelValidatorTest
	{
		public ApiStudentServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Email_Create_null()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Update_null()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Create_length()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void Email_Update_length()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void FamilyId_Create_Valid_Reference()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.FamilyByFamilyId(It.IsAny<int>())).Returns(Task.FromResult<Family>(new Family()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.FamilyId, 1);
		}

		[Fact]
		public async void FamilyId_Create_Invalid_Reference()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.FamilyByFamilyId(It.IsAny<int>())).Returns(Task.FromResult<Family>(null));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);

			await validator.ValidateCreateAsync(new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FamilyId, 1);
		}

		[Fact]
		public async void FamilyId_Update_Valid_Reference()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.FamilyByFamilyId(It.IsAny<int>())).Returns(Task.FromResult<Family>(new Family()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.FamilyId, 1);
		}

		[Fact]
		public async void FamilyId_Update_Invalid_Reference()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.FamilyByFamilyId(It.IsAny<int>())).Returns(Task.FromResult<Family>(null));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FamilyId, 1);
		}

		[Fact]
		public async void FirstName_Create_null()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Update_null()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Create_length()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Update_length()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Create_null()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Update_null()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Create_length()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Update_length()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void Phone_Create_null()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
		}

		[Fact]
		public async void Phone_Update_null()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
		}

		[Fact]
		public async void Phone_Create_length()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}

		[Fact]
		public async void Phone_Update_length()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}

		[Fact]
		public async void UserId_Create_Valid_Reference()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Create_Invalid_Reference()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);

			await validator.ValidateCreateAsync(new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Valid_Reference()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Invalid_Reference()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiStudentServerRequestModelValidator(studentRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>0362aa8b13e5faf76ab230c46d8afacf</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/