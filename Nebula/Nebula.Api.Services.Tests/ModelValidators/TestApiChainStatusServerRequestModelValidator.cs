using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ChainStatus")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiChainStatusServerRequestModelValidatorTest
	{
		public ApiChainStatusServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
			chainStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatus()));

			var validator = new ApiChainStatusServerRequestModelValidator(chainStatusRepository.Object);
			await validator.ValidateCreateAsync(new ApiChainStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
			chainStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatus()));

			var validator = new ApiChainStatusServerRequestModelValidator(chainStatusRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiChainStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
			chainStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatus()));

			var validator = new ApiChainStatusServerRequestModelValidator(chainStatusRepository.Object);
			await validator.ValidateCreateAsync(new ApiChainStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
			chainStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatus()));

			var validator = new ApiChainStatusServerRequestModelValidator(chainStatusRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiChainStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
			chainStatusRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ChainStatus>(new ChainStatus()));
			var validator = new ApiChainStatusServerRequestModelValidator(chainStatusRepository.Object);

			await validator.ValidateCreateAsync(new ApiChainStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
			chainStatusRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ChainStatus>(null));
			var validator = new ApiChainStatusServerRequestModelValidator(chainStatusRepository.Object);

			await validator.ValidateCreateAsync(new ApiChainStatusServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
			chainStatusRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ChainStatus>(new ChainStatus()));
			var validator = new ApiChainStatusServerRequestModelValidator(chainStatusRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiChainStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
			chainStatusRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ChainStatus>(null));
			var validator = new ApiChainStatusServerRequestModelValidator(chainStatusRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiChainStatusServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>903d2561d71a9aed1abc789369bfcff1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/