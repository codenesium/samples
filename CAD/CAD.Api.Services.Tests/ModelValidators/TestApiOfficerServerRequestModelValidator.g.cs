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
	[Trait("Table", "Officer")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiOfficerServerRequestModelValidatorTest
	{
		public ApiOfficerServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Badge_Create_length()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateCreateAsync(new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Badge, new string('A', 129));
		}

		[Fact]
		public async void Badge_Update_length()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Badge, new string('A', 129));
		}

		[Fact]
		public async void Email_Create_null()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateCreateAsync(new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Update_null()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Create_length()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateCreateAsync(new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void Email_Update_length()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Create_null()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateCreateAsync(new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Update_null()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, null as string);
		}

		[Fact]
		public async void FirstName_Create_length()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateCreateAsync(new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void FirstName_Update_length()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FirstName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Create_null()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateCreateAsync(new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Update_null()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, null as string);
		}

		[Fact]
		public async void LastName_Create_length()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateCreateAsync(new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void LastName_Update_length()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastName, new string('A', 129));
		}

		[Fact]
		public async void Password_Create_null()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateCreateAsync(new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Password, null as string);
		}

		[Fact]
		public async void Password_Update_null()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Password, null as string);
		}

		[Fact]
		public async void Password_Create_length()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateCreateAsync(new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Password, new string('A', 129));
		}

		[Fact]
		public async void Password_Update_length()
		{
			Mock<IOfficerRepository> officerRepository = new Mock<IOfficerRepository>();
			officerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Officer()));

			var validator = new ApiOfficerServerRequestModelValidator(officerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Password, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>86cc219eaf03511eafbd5f5c9432d08b</Hash>
</Codenesium>*/