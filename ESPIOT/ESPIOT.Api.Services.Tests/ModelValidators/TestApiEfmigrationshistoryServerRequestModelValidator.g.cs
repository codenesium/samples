using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
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

namespace ESPIOTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Efmigrationshistory")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiEfmigrationshistoryServerRequestModelValidatorTest
	{
		public ApiEfmigrationshistoryServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void ProductVersion_Create_null()
		{
			Mock<IEfmigrationshistoryRepository> efmigrationshistoryRepository = new Mock<IEfmigrationshistoryRepository>();
			efmigrationshistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Efmigrationshistory()));

			var validator = new ApiEfmigrationshistoryServerRequestModelValidator(efmigrationshistoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiEfmigrationshistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductVersion, null as string);
		}

		[Fact]
		public async void ProductVersion_Update_null()
		{
			Mock<IEfmigrationshistoryRepository> efmigrationshistoryRepository = new Mock<IEfmigrationshistoryRepository>();
			efmigrationshistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Efmigrationshistory()));

			var validator = new ApiEfmigrationshistoryServerRequestModelValidator(efmigrationshistoryRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiEfmigrationshistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductVersion, null as string);
		}

		[Fact]
		public async void ProductVersion_Create_length()
		{
			Mock<IEfmigrationshistoryRepository> efmigrationshistoryRepository = new Mock<IEfmigrationshistoryRepository>();
			efmigrationshistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Efmigrationshistory()));

			var validator = new ApiEfmigrationshistoryServerRequestModelValidator(efmigrationshistoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiEfmigrationshistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductVersion, new string('A', 33));
		}

		[Fact]
		public async void ProductVersion_Update_length()
		{
			Mock<IEfmigrationshistoryRepository> efmigrationshistoryRepository = new Mock<IEfmigrationshistoryRepository>();
			efmigrationshistoryRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Efmigrationshistory()));

			var validator = new ApiEfmigrationshistoryServerRequestModelValidator(efmigrationshistoryRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiEfmigrationshistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductVersion, new string('A', 33));
		}
	}
}

/*<Codenesium>
    <Hash>4904ebdf03944cca1667ac356d7ab718</Hash>
</Codenesium>*/