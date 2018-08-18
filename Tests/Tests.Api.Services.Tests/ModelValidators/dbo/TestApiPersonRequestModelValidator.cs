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
	public partial class ApiPersonRequestModelValidatorTest
	{
		public ApiPersonRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void PersonName_Create_null()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonRequestModelValidator(personRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonName, null as string);
		}

		[Fact]
		public async void PersonName_Update_null()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonRequestModelValidator(personRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonName, null as string);
		}

		[Fact]
		public async void PersonName_Create_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonRequestModelValidator(personRepository.Object);
			await validator.ValidateCreateAsync(new ApiPersonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonName, new string('A', 51));
		}

		[Fact]
		public async void PersonName_Update_length()
		{
			Mock<IPersonRepository> personRepository = new Mock<IPersonRepository>();
			personRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Person()));

			var validator = new ApiPersonRequestModelValidator(personRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPersonRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PersonName, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>c5f4a6159c4719727ef6bec7403d55d5</Hash>
</Codenesium>*/