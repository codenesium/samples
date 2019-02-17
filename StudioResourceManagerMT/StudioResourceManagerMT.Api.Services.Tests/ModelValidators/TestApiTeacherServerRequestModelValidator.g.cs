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
	[Trait("Table", "Teacher")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTeacherServerRequestModelValidatorTest
	{
		public ApiTeacherServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Email_Create_null()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherServerRequestModelValidator(teacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Update_null()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherServerRequestModelValidator(teacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Create_length()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherServerRequestModelValidator(teacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void Email_Update_length()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherServerRequestModelValidator(teacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Create_null()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherServerRequestModelValidator(teacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Update_null()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherServerRequestModelValidator(teacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Create_length()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherServerRequestModelValidator(teacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Update_length()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherServerRequestModelValidator(teacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Create_null()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherServerRequestModelValidator(teacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Update_null()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherServerRequestModelValidator(teacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Create_length()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherServerRequestModelValidator(teacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Update_length()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherServerRequestModelValidator(teacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void Phone_Create_length()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherServerRequestModelValidator(teacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}

		[Fact]
		public async void Phone_Update_length()
		{
			Mock<ITeacherRepository> teacherRepository = new Mock<ITeacherRepository>();
			teacherRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Teacher()));

			var validator = new ApiTeacherServerRequestModelValidator(teacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>8156011a05a7c15e29ac95d51b41150f</Hash>
</Codenesium>*/