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
	[Trait("Table", "PersonPhone")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPersonPhoneRequestModelValidatorTest
	{
		public ApiPersonPhoneRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void PhoneNumber_Create_null()
		{
			Mock<IPersonPhoneRepository> personPhoneRepository = new Mock<IPersonPhoneRepository>();
			personPhoneRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonPhone()));

			var validator = new ApiPersonPhoneRequestModelValidator(personPhoneRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonPhoneRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PhoneNumber, null as string);
		}

		[Fact]
		public async void PhoneNumber_Update_null()
		{
			Mock<IPersonPhoneRepository> personPhoneRepository = new Mock<IPersonPhoneRepository>();
			personPhoneRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonPhone()));

			var validator = new ApiPersonPhoneRequestModelValidator(personPhoneRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonPhoneRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PhoneNumber, null as string);
		}

		[Fact]
		public async void PhoneNumber_Create_length()
		{
			Mock<IPersonPhoneRepository> personPhoneRepository = new Mock<IPersonPhoneRepository>();
			personPhoneRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonPhone()));

			var validator = new ApiPersonPhoneRequestModelValidator(personPhoneRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonPhoneRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PhoneNumber, new string('A', 26));
		}

		[Fact]
		public async void PhoneNumber_Update_length()
		{
			Mock<IPersonPhoneRepository> personPhoneRepository = new Mock<IPersonPhoneRepository>();
			personPhoneRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PersonPhone()));

			var validator = new ApiPersonPhoneRequestModelValidator(personPhoneRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonPhoneRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PhoneNumber, new string('A', 26));
		}
	}
}

/*<Codenesium>
    <Hash>51d5cc1b911d33104cc89547df32ae40</Hash>
</Codenesium>*/