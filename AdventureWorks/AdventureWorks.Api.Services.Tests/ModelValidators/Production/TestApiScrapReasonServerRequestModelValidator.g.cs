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
	[Trait("Table", "ScrapReason")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiScrapReasonServerRequestModelValidatorTest
	{
		public ApiScrapReasonServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IScrapReasonRepository> scrapReasonRepository = new Mock<IScrapReasonRepository>();
			scrapReasonRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new ScrapReason()));

			var validator = new ApiScrapReasonServerRequestModelValidator(scrapReasonRepository.Object);
			await validator.ValidateCreateAsync(new ApiScrapReasonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IScrapReasonRepository> scrapReasonRepository = new Mock<IScrapReasonRepository>();
			scrapReasonRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new ScrapReason()));

			var validator = new ApiScrapReasonServerRequestModelValidator(scrapReasonRepository.Object);
			await validator.ValidateUpdateAsync(default(short), new ApiScrapReasonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IScrapReasonRepository> scrapReasonRepository = new Mock<IScrapReasonRepository>();
			scrapReasonRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new ScrapReason()));

			var validator = new ApiScrapReasonServerRequestModelValidator(scrapReasonRepository.Object);
			await validator.ValidateCreateAsync(new ApiScrapReasonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IScrapReasonRepository> scrapReasonRepository = new Mock<IScrapReasonRepository>();
			scrapReasonRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new ScrapReason()));

			var validator = new ApiScrapReasonServerRequestModelValidator(scrapReasonRepository.Object);
			await validator.ValidateUpdateAsync(default(short), new ApiScrapReasonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IScrapReasonRepository> scrapReasonRepository = new Mock<IScrapReasonRepository>();
			scrapReasonRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ScrapReason>(new ScrapReason()));
			var validator = new ApiScrapReasonServerRequestModelValidator(scrapReasonRepository.Object);

			await validator.ValidateCreateAsync(new ApiScrapReasonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IScrapReasonRepository> scrapReasonRepository = new Mock<IScrapReasonRepository>();
			scrapReasonRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ScrapReason>(null));
			var validator = new ApiScrapReasonServerRequestModelValidator(scrapReasonRepository.Object);

			await validator.ValidateCreateAsync(new ApiScrapReasonServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IScrapReasonRepository> scrapReasonRepository = new Mock<IScrapReasonRepository>();
			scrapReasonRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ScrapReason>(new ScrapReason()));
			var validator = new ApiScrapReasonServerRequestModelValidator(scrapReasonRepository.Object);

			await validator.ValidateUpdateAsync(default(short), new ApiScrapReasonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IScrapReasonRepository> scrapReasonRepository = new Mock<IScrapReasonRepository>();
			scrapReasonRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ScrapReason>(null));
			var validator = new ApiScrapReasonServerRequestModelValidator(scrapReasonRepository.Object);

			await validator.ValidateUpdateAsync(default(short), new ApiScrapReasonServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>0007c0d3cd4d32851e95e8497297c894</Hash>
</Codenesium>*/