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
	[Trait("Table", "Culture")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCultureServerRequestModelValidatorTest
	{
		public ApiCultureServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ICultureRepository> cultureRepository = new Mock<ICultureRepository>();
			cultureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Culture()));

			var validator = new ApiCultureServerRequestModelValidator(cultureRepository.Object);
			await validator.ValidateCreateAsync(new ApiCultureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ICultureRepository> cultureRepository = new Mock<ICultureRepository>();
			cultureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Culture()));

			var validator = new ApiCultureServerRequestModelValidator(cultureRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiCultureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ICultureRepository> cultureRepository = new Mock<ICultureRepository>();
			cultureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Culture()));

			var validator = new ApiCultureServerRequestModelValidator(cultureRepository.Object);
			await validator.ValidateCreateAsync(new ApiCultureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ICultureRepository> cultureRepository = new Mock<ICultureRepository>();
			cultureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Culture()));

			var validator = new ApiCultureServerRequestModelValidator(cultureRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiCultureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<ICultureRepository> cultureRepository = new Mock<ICultureRepository>();
			cultureRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Culture>(new Culture()));
			var validator = new ApiCultureServerRequestModelValidator(cultureRepository.Object);

			await validator.ValidateCreateAsync(new ApiCultureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<ICultureRepository> cultureRepository = new Mock<ICultureRepository>();
			cultureRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Culture>(null));
			var validator = new ApiCultureServerRequestModelValidator(cultureRepository.Object);

			await validator.ValidateCreateAsync(new ApiCultureServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<ICultureRepository> cultureRepository = new Mock<ICultureRepository>();
			cultureRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Culture>(new Culture()));
			var validator = new ApiCultureServerRequestModelValidator(cultureRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiCultureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<ICultureRepository> cultureRepository = new Mock<ICultureRepository>();
			cultureRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Culture>(null));
			var validator = new ApiCultureServerRequestModelValidator(cultureRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiCultureServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>9ff4eda1876a72fbde7eb3df91564175</Hash>
</Codenesium>*/