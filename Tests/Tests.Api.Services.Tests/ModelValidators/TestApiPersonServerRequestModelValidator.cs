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
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Person")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPersonServerRequestModelValidatorTest
	{
		public ApiPersonServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void PersonName_Create_null()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonName, null as string);
		}

		[Fact]
		public async void PersonName_Update_null()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonName, null as string);
		}

		[Fact]
		public async void PersonName_Create_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonName, new string('A', 51));
		}

		[Fact]
		public async void PersonName_Update_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonServerRequestModelValidator(personRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonName, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>8ecaae1d96116ba80c1e04aff18da4b7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/