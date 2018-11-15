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
	[Trait("Table", "Currency")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCurrencyServerRequestModelValidatorTest
	{
		public ApiCurrencyServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ICurrencyRepository> currencyRepository = new Mock<ICurrencyRepository>();
			currencyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Currency()));

			var validator = new ApiCurrencyServerRequestModelValidator(currencyRepository.Object);
			await validator.ValidateCreateAsync(new ApiCurrencyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ICurrencyRepository> currencyRepository = new Mock<ICurrencyRepository>();
			currencyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Currency()));

			var validator = new ApiCurrencyServerRequestModelValidator(currencyRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiCurrencyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ICurrencyRepository> currencyRepository = new Mock<ICurrencyRepository>();
			currencyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Currency()));

			var validator = new ApiCurrencyServerRequestModelValidator(currencyRepository.Object);
			await validator.ValidateCreateAsync(new ApiCurrencyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ICurrencyRepository> currencyRepository = new Mock<ICurrencyRepository>();
			currencyRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Currency()));

			var validator = new ApiCurrencyServerRequestModelValidator(currencyRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiCurrencyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<ICurrencyRepository> currencyRepository = new Mock<ICurrencyRepository>();
			currencyRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Currency>(new Currency()));
			var validator = new ApiCurrencyServerRequestModelValidator(currencyRepository.Object);

			await validator.ValidateCreateAsync(new ApiCurrencyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<ICurrencyRepository> currencyRepository = new Mock<ICurrencyRepository>();
			currencyRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Currency>(null));
			var validator = new ApiCurrencyServerRequestModelValidator(currencyRepository.Object);

			await validator.ValidateCreateAsync(new ApiCurrencyServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<ICurrencyRepository> currencyRepository = new Mock<ICurrencyRepository>();
			currencyRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Currency>(new Currency()));
			var validator = new ApiCurrencyServerRequestModelValidator(currencyRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiCurrencyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<ICurrencyRepository> currencyRepository = new Mock<ICurrencyRepository>();
			currencyRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Currency>(null));
			var validator = new ApiCurrencyServerRequestModelValidator(currencyRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiCurrencyServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>cb2353d3754ce22b95f0ff39f21a2e28</Hash>
</Codenesium>*/