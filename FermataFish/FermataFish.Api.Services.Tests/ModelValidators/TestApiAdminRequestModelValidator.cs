using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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

namespace FermataFishNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Admin")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiAdminRequestModelValidatorTest
	{
		public ApiAdminRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Email_Create_length()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminRequestModelValidator(adminRepository.Object);
			await validator.ValidateCreateAsync(new ApiAdminRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void Email_Update_length()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminRequestModelValidator(adminRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAdminRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Create_length()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminRequestModelValidator(adminRepository.Object);
			await validator.ValidateCreateAsync(new ApiAdminRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Update_length()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminRequestModelValidator(adminRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAdminRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Create_length()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminRequestModelValidator(adminRepository.Object);
			await validator.ValidateCreateAsync(new ApiAdminRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Update_length()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminRequestModelValidator(adminRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAdminRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void Phone_Create_length()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminRequestModelValidator(adminRepository.Object);
			await validator.ValidateCreateAsync(new ApiAdminRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}

		[Fact]
		public async void Phone_Update_length()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Admin()));

			var validator = new ApiAdminRequestModelValidator(adminRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAdminRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Phone, new string('A', 129));
		}

		[Fact]
		public async void StudioId_Create_Valid_Reference()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

			var validator = new ApiAdminRequestModelValidator(adminRepository.Object);
			await validator.ValidateCreateAsync(new ApiAdminRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Create_Invalid_Reference()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

			var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

			await validator.ValidateCreateAsync(new ApiAdminRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Update_Valid_Reference()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

			var validator = new ApiAdminRequestModelValidator(adminRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAdminRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Update_Invalid_Reference()
		{
			Mock<IAdminRepository> adminRepository = new Mock<IAdminRepository>();
			adminRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

			var validator = new ApiAdminRequestModelValidator(adminRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiAdminRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>64893f560e3b618ab3241193a27e2c9a</Hash>
</Codenesium>*/