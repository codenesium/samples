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
	[Trait("Table", "ContactType")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiContactTypeServerRequestModelValidatorTest
	{
		public ApiContactTypeServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IContactTypeRepository> contactTypeRepository = new Mock<IContactTypeRepository>();
			contactTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ContactType()));

			var validator = new ApiContactTypeServerRequestModelValidator(contactTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiContactTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IContactTypeRepository> contactTypeRepository = new Mock<IContactTypeRepository>();
			contactTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ContactType()));

			var validator = new ApiContactTypeServerRequestModelValidator(contactTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiContactTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IContactTypeRepository> contactTypeRepository = new Mock<IContactTypeRepository>();
			contactTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ContactType()));

			var validator = new ApiContactTypeServerRequestModelValidator(contactTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiContactTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IContactTypeRepository> contactTypeRepository = new Mock<IContactTypeRepository>();
			contactTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ContactType()));

			var validator = new ApiContactTypeServerRequestModelValidator(contactTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiContactTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IContactTypeRepository> contactTypeRepository = new Mock<IContactTypeRepository>();
			contactTypeRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ContactType>(new ContactType()));
			var validator = new ApiContactTypeServerRequestModelValidator(contactTypeRepository.Object);

			await validator.ValidateCreateAsync(new ApiContactTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IContactTypeRepository> contactTypeRepository = new Mock<IContactTypeRepository>();
			contactTypeRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ContactType>(null));
			var validator = new ApiContactTypeServerRequestModelValidator(contactTypeRepository.Object);

			await validator.ValidateCreateAsync(new ApiContactTypeServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IContactTypeRepository> contactTypeRepository = new Mock<IContactTypeRepository>();
			contactTypeRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ContactType>(new ContactType()));
			var validator = new ApiContactTypeServerRequestModelValidator(contactTypeRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiContactTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IContactTypeRepository> contactTypeRepository = new Mock<IContactTypeRepository>();
			contactTypeRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ContactType>(null));
			var validator = new ApiContactTypeServerRequestModelValidator(contactTypeRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiContactTypeServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>ab60a23af08d2bea5e0ea27de909bf5e</Hash>
</Codenesium>*/