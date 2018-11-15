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
	[Trait("Table", "SchemaBPerson")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSchemaBPersonServerRequestModelValidatorTest
	{
		public ApiSchemaBPersonServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ISchemaBPersonRepository> schemaBPersonRepository = new Mock<ISchemaBPersonRepository>();
			schemaBPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaBPerson()));

			var validator = new ApiSchemaBPersonServerRequestModelValidator(schemaBPersonRepository.Object);
			await validator.ValidateCreateAsync(new ApiSchemaBPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ISchemaBPersonRepository> schemaBPersonRepository = new Mock<ISchemaBPersonRepository>();
			schemaBPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaBPerson()));

			var validator = new ApiSchemaBPersonServerRequestModelValidator(schemaBPersonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSchemaBPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ISchemaBPersonRepository> schemaBPersonRepository = new Mock<ISchemaBPersonRepository>();
			schemaBPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaBPerson()));

			var validator = new ApiSchemaBPersonServerRequestModelValidator(schemaBPersonRepository.Object);
			await validator.ValidateCreateAsync(new ApiSchemaBPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ISchemaBPersonRepository> schemaBPersonRepository = new Mock<ISchemaBPersonRepository>();
			schemaBPersonRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SchemaBPerson()));

			var validator = new ApiSchemaBPersonServerRequestModelValidator(schemaBPersonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSchemaBPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>a683dca5225574a38ac64ce24ed0911a</Hash>
</Codenesium>*/