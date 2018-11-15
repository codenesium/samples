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
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "User")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiUserServerRequestModelValidatorTest
	{
		public ApiUserServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void BioImgUrl_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.BioImgUrl, new string('A', 33));
		}

		[Fact]
		public async void BioImgUrl_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.BioImgUrl, new string('A', 33));
		}

		[Fact]
		public async void ContentDescription_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ContentDescription, new string('A', 129));
		}

		[Fact]
		public async void ContentDescription_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ContentDescription, new string('A', 129));
		}

		[Fact]
		public async void Email_Create_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Update_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 33));
		}

		[Fact]
		public async void Email_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 33));
		}

		[Fact]
		public async void FullName_Create_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FullName, null as string);
		}

		[Fact]
		public async void FullName_Update_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FullName, null as string);
		}

		[Fact]
		public async void FullName_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FullName, new string('A', 65));
		}

		[Fact]
		public async void FullName_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FullName, new string('A', 65));
		}

		[Fact]
		public async void HeaderImgUrl_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.HeaderImgUrl, new string('A', 33));
		}

		[Fact]
		public async void HeaderImgUrl_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.HeaderImgUrl, new string('A', 33));
		}

		[Fact]
		public async void Interest_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Interest, new string('A', 129));
		}

		[Fact]
		public async void Interest_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Interest, new string('A', 129));
		}

		[Fact]
		public async void LocationLocationId_Create_Valid_Reference()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.LocationByLocationLocationId(It.IsAny<int>())).Returns(Task.FromResult<Location>(new Location()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LocationLocationId, 1);
		}

		[Fact]
		public async void LocationLocationId_Create_Invalid_Reference()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.LocationByLocationLocationId(It.IsAny<int>())).Returns(Task.FromResult<Location>(null));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);

			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LocationLocationId, 1);
		}

		[Fact]
		public async void LocationLocationId_Update_Valid_Reference()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.LocationByLocationLocationId(It.IsAny<int>())).Returns(Task.FromResult<Location>(new Location()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LocationLocationId, 1);
		}

		[Fact]
		public async void LocationLocationId_Update_Invalid_Reference()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.LocationByLocationLocationId(It.IsAny<int>())).Returns(Task.FromResult<Location>(null));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LocationLocationId, 1);
		}

		[Fact]
		public async void Password_Create_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Password, null as string);
		}

		[Fact]
		public async void Password_Update_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Password, null as string);
		}

		[Fact]
		public async void Password_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Password, new string('A', 33));
		}

		[Fact]
		public async void Password_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Password, new string('A', 33));
		}

		[Fact]
		public async void PhoneNumber_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PhoneNumber, new string('A', 33));
		}

		[Fact]
		public async void PhoneNumber_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PhoneNumber, new string('A', 33));
		}

		[Fact]
		public async void Privacy_Create_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Privacy, null as string);
		}

		[Fact]
		public async void Privacy_Update_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Privacy, null as string);
		}

		[Fact]
		public async void Privacy_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Privacy, new string('A', 2));
		}

		[Fact]
		public async void Privacy_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Privacy, new string('A', 2));
		}

		[Fact]
		public async void Username_Create_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Username, null as string);
		}

		[Fact]
		public async void Username_Update_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Username, null as string);
		}

		[Fact]
		public async void Username_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Username, new string('A', 65));
		}

		[Fact]
		public async void Username_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Username, new string('A', 65));
		}

		[Fact]
		public async void Website_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Website, new string('A', 33));
		}

		[Fact]
		public async void Website_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Website, new string('A', 33));
		}
	}
}

/*<Codenesium>
    <Hash>630d8351dfc79da974022da2f08d1a7f</Hash>
</Codenesium>*/