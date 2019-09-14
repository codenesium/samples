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
	[Trait("Table", "Admin")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiAdminServerRequestModelValidatorTest
	{
		public ApiAdminServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Email_Create_null()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);
			await validator.ValidateCreateAsync(new ApiAdminServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Update_null()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAdminServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Create_length()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);
			await validator.ValidateCreateAsync(new ApiAdminServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void Email_Update_length()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAdminServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Create_null()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);
			await validator.ValidateCreateAsync(new ApiAdminServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Update_null()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAdminServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Create_length()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);
			await validator.ValidateCreateAsync(new ApiAdminServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Update_length()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAdminServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Create_null()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);
			await validator.ValidateCreateAsync(new ApiAdminServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Update_null()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAdminServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Create_length()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);
			await validator.ValidateCreateAsync(new ApiAdminServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Update_length()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAdminServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void Phone_Create_length()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);
			await validator.ValidateCreateAsync(new ApiAdminServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}

		[Fact]
		public async void Phone_Update_length()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAdminServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}

		[Fact]
		public async void UserId_Create_Valid_Reference()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);
			await validator.ValidateCreateAsync(new ApiAdminServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Create_Invalid_Reference()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);

			await validator.ValidateCreateAsync(new ApiAdminServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Valid_Reference()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAdminServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Invalid_Reference()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiAdminServerRequestModelValidator(adminRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiAdminServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>c8eecb36dced8b559954eb64702fbc9a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/