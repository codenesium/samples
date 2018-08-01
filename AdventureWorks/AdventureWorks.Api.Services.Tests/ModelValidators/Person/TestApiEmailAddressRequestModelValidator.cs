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
	[Trait("Table", "EmailAddress")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiEmailAddressRequestModelValidatorTest
	{
		public ApiEmailAddressRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void EmailAddress1_Create_length()
		{
			Mock<IEmailAddressRepository> emailAddressRepository = new Mock<IEmailAddressRepository>();
			emailAddressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EmailAddress()));

			var validator = new ApiEmailAddressRequestModelValidator(emailAddressRepository.Object);
			await validator.ValidateCreateAsync(new ApiEmailAddressRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmailAddress1, new string('A', 51));
		}

		[Fact]
		public async void EmailAddress1_Update_length()
		{
			Mock<IEmailAddressRepository> emailAddressRepository = new Mock<IEmailAddressRepository>();
			emailAddressRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new EmailAddress()));

			var validator = new ApiEmailAddressRequestModelValidator(emailAddressRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEmailAddressRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmailAddress1, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>f59458ee607b1e6527cec989fe1fa05f</Hash>
</Codenesium>*/