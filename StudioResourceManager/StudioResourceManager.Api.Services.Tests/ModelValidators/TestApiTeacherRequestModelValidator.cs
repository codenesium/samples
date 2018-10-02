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
	[Trait("Table", "Teacher")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTeacherRequestModelValidatorTest
	{
		public ApiTeacherRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Email_Create_null()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Update_null()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Create_length()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void Email_Update_length()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Create_null()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Update_null()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Create_length()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Update_length()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Create_null()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Update_null()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Create_length()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Update_length()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void Phone_Create_length()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}

		[Fact]
		public async void Phone_Update_length()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}

		[Fact]
		public async void UserId_Create_Valid_Reference()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Create_Invalid_Reference()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

			await validator.ValidateCreateAsync(new ApiTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Valid_Reference()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Invalid_Reference()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiTeacherRequestModelValidator(teacherRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>24392b28eeab80a651f79bd699539702</Hash>
</Codenesium>*/