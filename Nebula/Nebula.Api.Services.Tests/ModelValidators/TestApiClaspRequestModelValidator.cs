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
	public partial class ApiClaspRequestModelValidatorTest
	{
		public ApiClaspRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void NextChainId_Create_Valid_Reference()
		{
			Mock<IClaspRepository> claspRepository = new Mock<IClaspRepository>();
			claspRepository.Setup(x => x.GetChain(It.IsAny<int>())).Returns(Task.FromResult<Chain>(new Chain()));

			var validator = new ApiClaspRequestModelValidator(claspRepository.Object);
			await validator.ValidateCreateAsync(new ApiClaspRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.NextChainId, 1);
		}

		[Fact]
		public async void NextChainId_Create_Invalid_Reference()
		{
			Mock<IClaspRepository> claspRepository = new Mock<IClaspRepository>();
			claspRepository.Setup(x => x.GetChain(It.IsAny<int>())).Returns(Task.FromResult<Chain>(null));

			var validator = new ApiClaspRequestModelValidator(claspRepository.Object);

			await validator.ValidateCreateAsync(new ApiClaspRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.NextChainId, 1);
		}

		[Fact]
		public async void NextChainId_Update_Valid_Reference()
		{
			Mock<IClaspRepository> claspRepository = new Mock<IClaspRepository>();
			claspRepository.Setup(x => x.GetChain(It.IsAny<int>())).Returns(Task.FromResult<Chain>(new Chain()));

			var validator = new ApiClaspRequestModelValidator(claspRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiClaspRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.NextChainId, 1);
		}

		[Fact]
		public async void NextChainId_Update_Invalid_Reference()
		{
			Mock<IClaspRepository> claspRepository = new Mock<IClaspRepository>();
			claspRepository.Setup(x => x.GetChain(It.IsAny<int>())).Returns(Task.FromResult<Chain>(null));

			var validator = new ApiClaspRequestModelValidator(claspRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiClaspRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.NextChainId, 1);
		}

		[Fact]
		public async void PreviousChainId_Create_Valid_Reference()
		{
			Mock<IClaspRepository> claspRepository = new Mock<IClaspRepository>();
			claspRepository.Setup(x => x.GetChain(It.IsAny<int>())).Returns(Task.FromResult<Chain>(new Chain()));

			var validator = new ApiClaspRequestModelValidator(claspRepository.Object);
			await validator.ValidateCreateAsync(new ApiClaspRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PreviousChainId, 1);
		}

		[Fact]
		public async void PreviousChainId_Create_Invalid_Reference()
		{
			Mock<IClaspRepository> claspRepository = new Mock<IClaspRepository>();
			claspRepository.Setup(x => x.GetChain(It.IsAny<int>())).Returns(Task.FromResult<Chain>(null));

			var validator = new ApiClaspRequestModelValidator(claspRepository.Object);

			await validator.ValidateCreateAsync(new ApiClaspRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PreviousChainId, 1);
		}

		[Fact]
		public async void PreviousChainId_Update_Valid_Reference()
		{
			Mock<IClaspRepository> claspRepository = new Mock<IClaspRepository>();
			claspRepository.Setup(x => x.GetChain(It.IsAny<int>())).Returns(Task.FromResult<Chain>(new Chain()));

			var validator = new ApiClaspRequestModelValidator(claspRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiClaspRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PreviousChainId, 1);
		}

		[Fact]
		public async void PreviousChainId_Update_Invalid_Reference()
		{
			Mock<IClaspRepository> claspRepository = new Mock<IClaspRepository>();
			claspRepository.Setup(x => x.GetChain(It.IsAny<int>())).Returns(Task.FromResult<Chain>(null));

			var validator = new ApiClaspRequestModelValidator(claspRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiClaspRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PreviousChainId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>94e94507f3bdd0d5b39037a3d54e831c</Hash>
</Codenesium>*/