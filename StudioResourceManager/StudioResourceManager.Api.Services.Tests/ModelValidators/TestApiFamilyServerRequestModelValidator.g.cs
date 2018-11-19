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
	[Trait("Table", "Family")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiFamilyServerRequestModelValidatorTest
	{
		public ApiFamilyServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void PrimaryContactEmail_Create_length()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyServerRequestModelValidator(familyRepository.Object);
			await validator.ValidateCreateAsync(new ApiFamilyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PrimaryContactEmail, new string('A', 129));
		}

		[Fact]
		public async void PrimaryContactEmail_Update_length()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyServerRequestModelValidator(familyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFamilyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PrimaryContactEmail, new string('A', 129));
		}

		[Fact]
		public async void PrimaryContactFirstName_Create_length()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyServerRequestModelValidator(familyRepository.Object);
			await validator.ValidateCreateAsync(new ApiFamilyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PrimaryContactFirstName, new string('A', 129));
		}

		[Fact]
		public async void PrimaryContactFirstName_Update_length()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyServerRequestModelValidator(familyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFamilyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PrimaryContactFirstName, new string('A', 129));
		}

		[Fact]
		public async void PrimaryContactLastName_Create_length()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyServerRequestModelValidator(familyRepository.Object);
			await validator.ValidateCreateAsync(new ApiFamilyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PrimaryContactLastName, new string('A', 129));
		}

		[Fact]
		public async void PrimaryContactLastName_Update_length()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyServerRequestModelValidator(familyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFamilyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PrimaryContactLastName, new string('A', 129));
		}

		[Fact]
		public async void PrimaryContactPhone_Create_null()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyServerRequestModelValidator(familyRepository.Object);
			await validator.ValidateCreateAsync(new ApiFamilyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PrimaryContactPhone, null as string);
		}

		[Fact]
		public async void PrimaryContactPhone_Update_null()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyServerRequestModelValidator(familyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFamilyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PrimaryContactPhone, null as string);
		}

		[Fact]
		public async void PrimaryContactPhone_Create_length()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyServerRequestModelValidator(familyRepository.Object);
			await validator.ValidateCreateAsync(new ApiFamilyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PrimaryContactPhone, new string('A', 129));
		}

		[Fact]
		public async void PrimaryContactPhone_Update_length()
		{
			Mock<IFamilyRepository> familyRepository = new Mock<IFamilyRepository>();
			familyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Family()));

			var validator = new ApiFamilyServerRequestModelValidator(familyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFamilyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PrimaryContactPhone, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>783c48b9a5085dd6f64e73fec7ededc9</Hash>
</Codenesium>*/