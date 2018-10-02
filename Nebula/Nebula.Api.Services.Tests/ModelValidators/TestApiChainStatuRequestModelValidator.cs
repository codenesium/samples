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
	[Trait("Table", "ChainStatu")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiChainStatuRequestModelValidatorTest
	{
		public ApiChainStatuRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IChainStatuRepository> chainStatuRepository = new Mock<IChainStatuRepository>();
			chainStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatu()));

			var validator = new ApiChainStatuRequestModelValidator(chainStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiChainStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IChainStatuRepository> chainStatuRepository = new Mock<IChainStatuRepository>();
			chainStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatu()));

			var validator = new ApiChainStatuRequestModelValidator(chainStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiChainStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IChainStatuRepository> chainStatuRepository = new Mock<IChainStatuRepository>();
			chainStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatu()));

			var validator = new ApiChainStatuRequestModelValidator(chainStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiChainStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IChainStatuRepository> chainStatuRepository = new Mock<IChainStatuRepository>();
			chainStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatu()));

			var validator = new ApiChainStatuRequestModelValidator(chainStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiChainStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IChainStatuRepository> chainStatuRepository = new Mock<IChainStatuRepository>();
			chainStatuRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ChainStatu>(new ChainStatu()));
			var validator = new ApiChainStatuRequestModelValidator(chainStatuRepository.Object);

			await validator.ValidateCreateAsync(new ApiChainStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IChainStatuRepository> chainStatuRepository = new Mock<IChainStatuRepository>();
			chainStatuRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ChainStatu>(null));
			var validator = new ApiChainStatuRequestModelValidator(chainStatuRepository.Object);

			await validator.ValidateCreateAsync(new ApiChainStatuRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IChainStatuRepository> chainStatuRepository = new Mock<IChainStatuRepository>();
			chainStatuRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ChainStatu>(new ChainStatu()));
			var validator = new ApiChainStatuRequestModelValidator(chainStatuRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiChainStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IChainStatuRepository> chainStatuRepository = new Mock<IChainStatuRepository>();
			chainStatuRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ChainStatu>(null));
			var validator = new ApiChainStatuRequestModelValidator(chainStatuRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiChainStatuRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>d568d6af39d52c702bb1322535dbbfd6</Hash>
</Codenesium>*/