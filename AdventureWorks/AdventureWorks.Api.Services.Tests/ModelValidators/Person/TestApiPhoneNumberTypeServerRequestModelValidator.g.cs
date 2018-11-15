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
	[Trait("Table", "PhoneNumberType")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPhoneNumberTypeServerRequestModelValidatorTest
	{
		public ApiPhoneNumberTypeServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IPhoneNumberTypeRepository> phoneNumberTypeRepository = new Mock<IPhoneNumberTypeRepository>();
			phoneNumberTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PhoneNumberType()));

			var validator = new ApiPhoneNumberTypeServerRequestModelValidator(phoneNumberTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiPhoneNumberTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IPhoneNumberTypeRepository> phoneNumberTypeRepository = new Mock<IPhoneNumberTypeRepository>();
			phoneNumberTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PhoneNumberType()));

			var validator = new ApiPhoneNumberTypeServerRequestModelValidator(phoneNumberTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPhoneNumberTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IPhoneNumberTypeRepository> phoneNumberTypeRepository = new Mock<IPhoneNumberTypeRepository>();
			phoneNumberTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PhoneNumberType()));

			var validator = new ApiPhoneNumberTypeServerRequestModelValidator(phoneNumberTypeRepository.Object);
			await validator.ValidateCreateAsync(new ApiPhoneNumberTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IPhoneNumberTypeRepository> phoneNumberTypeRepository = new Mock<IPhoneNumberTypeRepository>();
			phoneNumberTypeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PhoneNumberType()));

			var validator = new ApiPhoneNumberTypeServerRequestModelValidator(phoneNumberTypeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPhoneNumberTypeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>e0dac46fdc5d6c732a8db4438b74985d</Hash>
</Codenesium>*/