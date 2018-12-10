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
	[Trait("Table", "Clasp")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiClaspServerRequestModelValidatorTest
	{
		public ApiClaspServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void NextChainId_Create_Valid_Reference()
		{
			Mock<IClaspRepository> claspRepository = new Mock<IClaspRepository>();
			claspRepository.Setup(x => x.ChainByNextChainId(It.IsAny<int>())).Returns(Task.FromResult<Chain>(new Chain()));

			var validator = new ApiClaspServerRequestModelValidator(claspRepository.Object);
			await validator.ValidateCreateAsync(new ApiClaspServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.NextChainId, 1);
		}

		[Fact]
		public async void NextChainId_Create_Invalid_Reference()
		{
			Mock<IClaspRepository> claspRepository = new Mock<IClaspRepository>();
			claspRepository.Setup(x => x.ChainByNextChainId(It.IsAny<int>())).Returns(Task.FromResult<Chain>(null));

			var validator = new ApiClaspServerRequestModelValidator(claspRepository.Object);

			await validator.ValidateCreateAsync(new ApiClaspServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.NextChainId, 1);
		}

		[Fact]
		public async void NextChainId_Update_Valid_Reference()
		{
			Mock<IClaspRepository> claspRepository = new Mock<IClaspRepository>();
			claspRepository.Setup(x => x.ChainByNextChainId(It.IsAny<int>())).Returns(Task.FromResult<Chain>(new Chain()));

			var validator = new ApiClaspServerRequestModelValidator(claspRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiClaspServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.NextChainId, 1);
		}

		[Fact]
		public async void NextChainId_Update_Invalid_Reference()
		{
			Mock<IClaspRepository> claspRepository = new Mock<IClaspRepository>();
			claspRepository.Setup(x => x.ChainByNextChainId(It.IsAny<int>())).Returns(Task.FromResult<Chain>(null));

			var validator = new ApiClaspServerRequestModelValidator(claspRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiClaspServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.NextChainId, 1);
		}

		[Fact]
		public async void PreviousChainId_Create_Valid_Reference()
		{
			Mock<IClaspRepository> claspRepository = new Mock<IClaspRepository>();
			claspRepository.Setup(x => x.ChainByPreviousChainId(It.IsAny<int>())).Returns(Task.FromResult<Chain>(new Chain()));

			var validator = new ApiClaspServerRequestModelValidator(claspRepository.Object);
			await validator.ValidateCreateAsync(new ApiClaspServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PreviousChainId, 1);
		}

		[Fact]
		public async void PreviousChainId_Create_Invalid_Reference()
		{
			Mock<IClaspRepository> claspRepository = new Mock<IClaspRepository>();
			claspRepository.Setup(x => x.ChainByPreviousChainId(It.IsAny<int>())).Returns(Task.FromResult<Chain>(null));

			var validator = new ApiClaspServerRequestModelValidator(claspRepository.Object);

			await validator.ValidateCreateAsync(new ApiClaspServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PreviousChainId, 1);
		}

		[Fact]
		public async void PreviousChainId_Update_Valid_Reference()
		{
			Mock<IClaspRepository> claspRepository = new Mock<IClaspRepository>();
			claspRepository.Setup(x => x.ChainByPreviousChainId(It.IsAny<int>())).Returns(Task.FromResult<Chain>(new Chain()));

			var validator = new ApiClaspServerRequestModelValidator(claspRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiClaspServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PreviousChainId, 1);
		}

		[Fact]
		public async void PreviousChainId_Update_Invalid_Reference()
		{
			Mock<IClaspRepository> claspRepository = new Mock<IClaspRepository>();
			claspRepository.Setup(x => x.ChainByPreviousChainId(It.IsAny<int>())).Returns(Task.FromResult<Chain>(null));

			var validator = new ApiClaspServerRequestModelValidator(claspRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiClaspServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PreviousChainId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>61ec913b0f1e40c701b807c66100cd86</Hash>
</Codenesium>*/