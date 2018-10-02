using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Student")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiStudentRequestModelValidatorTest
	{
		public ApiStudentRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Email_Create_null()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Update_null()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Create_length()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void Email_Update_length()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void FamilyId_Create_Valid_Reference()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.GetFamily(It.IsAny<int>())).Returns(Task.FromResult<Family>(new Family()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.FamilyId, 1);
		}

		[Fact]
		public async void FamilyId_Create_Invalid_Reference()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.GetFamily(It.IsAny<int>())).Returns(Task.FromResult<Family>(null));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);

			await validator.ValidateCreateAsync(new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FamilyId, 1);
		}

		[Fact]
		public async void FamilyId_Update_Valid_Reference()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.GetFamily(It.IsAny<int>())).Returns(Task.FromResult<Family>(new Family()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.FamilyId, 1);
		}

		[Fact]
		public async void FamilyId_Update_Invalid_Reference()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.GetFamily(It.IsAny<int>())).Returns(Task.FromResult<Family>(null));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FamilyId, 1);
		}

		[Fact]
		public async void FirstName_Create_null()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Update_null()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Create_length()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Update_length()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Create_null()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Update_null()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Create_length()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Update_length()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void Phone_Create_null()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
		}

		[Fact]
		public async void Phone_Update_null()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, null as string);
		}

		[Fact]
		public async void Phone_Create_length()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}

		[Fact]
		public async void Phone_Update_length()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Student()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}

		[Fact]
		public async void UserId_Create_Valid_Reference()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Create_Invalid_Reference()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);

			await validator.ValidateCreateAsync(new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Valid_Reference()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Invalid_Reference()
		{
			Mock<IStudentRepository> studentRepository = new Mock<IStudentRepository>();
			studentRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiStudentRequestModelValidator(studentRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>2893834c51d85fd5f9a308eac5de90b9</Hash>
</Codenesium>*/