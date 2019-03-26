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
	[Trait("Table", "CurrencyRate")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCurrencyRateServerRequestModelValidatorTest
	{
		public ApiCurrencyRateServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void FromCurrencyCode_Create_null()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CurrencyRate()));

			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);
			await validator.ValidateCreateAsync(new ApiCurrencyRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FromCurrencyCode, null as string);
		}

		[Fact]
		public async void FromCurrencyCode_Update_null()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CurrencyRate()));

			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCurrencyRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FromCurrencyCode, null as string);
		}

		[Fact]
		public async void FromCurrencyCode_Create_length()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CurrencyRate()));

			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);
			await validator.ValidateCreateAsync(new ApiCurrencyRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FromCurrencyCode, new string('A', 4));
		}

		[Fact]
		public async void FromCurrencyCode_Update_length()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CurrencyRate()));

			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCurrencyRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FromCurrencyCode, new string('A', 4));
		}

		[Fact]
		public async void FromCurrencyCode_Create_Valid_Reference()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.CurrencyByFromCurrencyCode(It.IsAny<string>())).Returns(Task.FromResult<Currency>(new Currency()));

			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);
			await validator.ValidateCreateAsync(new ApiCurrencyRateServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.FromCurrencyCode, "A");
		}

		[Fact]
		public async void FromCurrencyCode_Create_Invalid_Reference()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.CurrencyByFromCurrencyCode(It.IsAny<string>())).Returns(Task.FromResult<Currency>(null));

			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);

			await validator.ValidateCreateAsync(new ApiCurrencyRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FromCurrencyCode, "A");
		}

		[Fact]
		public async void FromCurrencyCode_Update_Valid_Reference()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.CurrencyByFromCurrencyCode(It.IsAny<string>())).Returns(Task.FromResult<Currency>(new Currency()));

			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCurrencyRateServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.FromCurrencyCode, "A");
		}

		[Fact]
		public async void FromCurrencyCode_Update_Invalid_Reference()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.CurrencyByFromCurrencyCode(It.IsAny<string>())).Returns(Task.FromResult<Currency>(null));

			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCurrencyRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FromCurrencyCode, "A");
		}

		[Fact]
		public async void ToCurrencyCode_Create_null()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CurrencyRate()));

			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);
			await validator.ValidateCreateAsync(new ApiCurrencyRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ToCurrencyCode, null as string);
		}

		[Fact]
		public async void ToCurrencyCode_Update_null()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CurrencyRate()));

			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCurrencyRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ToCurrencyCode, null as string);
		}

		[Fact]
		public async void ToCurrencyCode_Create_length()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CurrencyRate()));

			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);
			await validator.ValidateCreateAsync(new ApiCurrencyRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ToCurrencyCode, new string('A', 4));
		}

		[Fact]
		public async void ToCurrencyCode_Update_length()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new CurrencyRate()));

			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCurrencyRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ToCurrencyCode, new string('A', 4));
		}

		[Fact]
		public async void ToCurrencyCode_Create_Valid_Reference()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.CurrencyByToCurrencyCode(It.IsAny<string>())).Returns(Task.FromResult<Currency>(new Currency()));

			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);
			await validator.ValidateCreateAsync(new ApiCurrencyRateServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ToCurrencyCode, "A");
		}

		[Fact]
		public async void ToCurrencyCode_Create_Invalid_Reference()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.CurrencyByToCurrencyCode(It.IsAny<string>())).Returns(Task.FromResult<Currency>(null));

			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);

			await validator.ValidateCreateAsync(new ApiCurrencyRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ToCurrencyCode, "A");
		}

		[Fact]
		public async void ToCurrencyCode_Update_Valid_Reference()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.CurrencyByToCurrencyCode(It.IsAny<string>())).Returns(Task.FromResult<Currency>(new Currency()));

			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCurrencyRateServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ToCurrencyCode, "A");
		}

		[Fact]
		public async void ToCurrencyCode_Update_Invalid_Reference()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.CurrencyByToCurrencyCode(It.IsAny<string>())).Returns(Task.FromResult<Currency>(null));

			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCurrencyRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ToCurrencyCode, "A");
		}

		[Fact]
		private async void BeUniqueByCurrencyRateDateFromCurrencyCodeToCurrencyCode_Create_Exists()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<CurrencyRate>(new CurrencyRate()));
			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);

			await validator.ValidateCreateAsync(new ApiCurrencyRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CurrencyRateDate, DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		private async void BeUniqueByCurrencyRateDateFromCurrencyCodeToCurrencyCode_Create_Not_Exists()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<CurrencyRate>(null));
			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);

			await validator.ValidateCreateAsync(new ApiCurrencyRateServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CurrencyRateDate, DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		private async void BeUniqueByCurrencyRateDateFromCurrencyCodeToCurrencyCode_Update_Exists()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<CurrencyRate>(new CurrencyRate()));
			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCurrencyRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CurrencyRateDate, DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		private async void BeUniqueByCurrencyRateDateFromCurrencyCodeToCurrencyCode_Update_Not_Exists()
		{
			Mock<ICurrencyRateRepository> currencyRateRepository = new Mock<ICurrencyRateRepository>();
			currencyRateRepository.Setup(x => x.ByCurrencyRateDateFromCurrencyCodeToCurrencyCode(It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<CurrencyRate>(null));
			var validator = new ApiCurrencyRateServerRequestModelValidator(currencyRateRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCurrencyRateServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CurrencyRateDate, DateTime.Parse("1/1/1987 12:00:00 AM"));
		}
	}
}

/*<Codenesium>
    <Hash>cdf37da9f35fb6e3bf1939dbe428e7a9</Hash>
</Codenesium>*/