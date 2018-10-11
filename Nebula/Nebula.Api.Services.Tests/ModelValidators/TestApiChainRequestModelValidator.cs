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
	[Trait("Table", "Chain")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiChainRequestModelValidatorTest
	{
		public ApiChainRequestModelValidatorTest()
		{
		}

		// table.Columns[i].GetReferenceTable().AppTableName= ChainStatus
		[Fact]
		public async void ChainStatusId_Create_Valid_Reference()
		{
			Mock<IChainRepository> chainRepository = new Mock<IChainRepository>();
			chainRepository.Setup(x => x.ChainStatusByChainStatusId(It.IsAny<int>())).Returns(Task.FromResult<ChainStatus>(new ChainStatus()));

			var validator = new ApiChainRequestModelValidator(chainRepository.Object);
			await validator.ValidateCreateAsync(new ApiChainRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ChainStatusId, 1);
		}

		[Fact]
		public async void ChainStatusId_Create_Invalid_Reference()
		{
			Mock<IChainRepository> chainRepository = new Mock<IChainRepository>();
			chainRepository.Setup(x => x.ChainStatusByChainStatusId(It.IsAny<int>())).Returns(Task.FromResult<ChainStatus>(null));

			var validator = new ApiChainRequestModelValidator(chainRepository.Object);

			await validator.ValidateCreateAsync(new ApiChainRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ChainStatusId, 1);
		}

		[Fact]
		public async void ChainStatusId_Update_Valid_Reference()
		{
			Mock<IChainRepository> chainRepository = new Mock<IChainRepository>();
			chainRepository.Setup(x => x.ChainStatusByChainStatusId(It.IsAny<int>())).Returns(Task.FromResult<ChainStatus>(new ChainStatus()));

			var validator = new ApiChainRequestModelValidator(chainRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiChainRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ChainStatusId, 1);
		}

		[Fact]
		public async void ChainStatusId_Update_Invalid_Reference()
		{
			Mock<IChainRepository> chainRepository = new Mock<IChainRepository>();
			chainRepository.Setup(x => x.ChainStatusByChainStatusId(It.IsAny<int>())).Returns(Task.FromResult<ChainStatus>(null));

			var validator = new ApiChainRequestModelValidator(chainRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiChainRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ChainStatusId, 1);
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IChainRepository> chainRepository = new Mock<IChainRepository>();
			chainRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Chain()));

			var validator = new ApiChainRequestModelValidator(chainRepository.Object);
			await validator.ValidateCreateAsync(new ApiChainRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IChainRepository> chainRepository = new Mock<IChainRepository>();
			chainRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Chain()));

			var validator = new ApiChainRequestModelValidator(chainRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiChainRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IChainRepository> chainRepository = new Mock<IChainRepository>();
			chainRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Chain()));

			var validator = new ApiChainRequestModelValidator(chainRepository.Object);
			await validator.ValidateCreateAsync(new ApiChainRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IChainRepository> chainRepository = new Mock<IChainRepository>();
			chainRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Chain()));

			var validator = new ApiChainRequestModelValidator(chainRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiChainRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		// table.Columns[i].GetReferenceTable().AppTableName= Team
		[Fact]
		public async void TeamId_Create_Valid_Reference()
		{
			Mock<IChainRepository> chainRepository = new Mock<IChainRepository>();
			chainRepository.Setup(x => x.TeamByTeamId(It.IsAny<int>())).Returns(Task.FromResult<Team>(new Team()));

			var validator = new ApiChainRequestModelValidator(chainRepository.Object);
			await validator.ValidateCreateAsync(new ApiChainRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeamId, 1);
		}

		[Fact]
		public async void TeamId_Create_Invalid_Reference()
		{
			Mock<IChainRepository> chainRepository = new Mock<IChainRepository>();
			chainRepository.Setup(x => x.TeamByTeamId(It.IsAny<int>())).Returns(Task.FromResult<Team>(null));

			var validator = new ApiChainRequestModelValidator(chainRepository.Object);

			await validator.ValidateCreateAsync(new ApiChainRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeamId, 1);
		}

		[Fact]
		public async void TeamId_Update_Valid_Reference()
		{
			Mock<IChainRepository> chainRepository = new Mock<IChainRepository>();
			chainRepository.Setup(x => x.TeamByTeamId(It.IsAny<int>())).Returns(Task.FromResult<Team>(new Team()));

			var validator = new ApiChainRequestModelValidator(chainRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiChainRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeamId, 1);
		}

		[Fact]
		public async void TeamId_Update_Invalid_Reference()
		{
			Mock<IChainRepository> chainRepository = new Mock<IChainRepository>();
			chainRepository.Setup(x => x.TeamByTeamId(It.IsAny<int>())).Returns(Task.FromResult<Team>(null));

			var validator = new ApiChainRequestModelValidator(chainRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiChainRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeamId, 1);
		}

		[Fact]
		private async void BeUniqueByExternalId_Create_Exists()
		{
			Mock<IChainRepository> chainRepository = new Mock<IChainRepository>();
			chainRepository.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Chain>(new Chain()));
			var validator = new ApiChainRequestModelValidator(chainRepository.Object);

			await validator.ValidateCreateAsync(new ApiChainRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByExternalId_Create_Not_Exists()
		{
			Mock<IChainRepository> chainRepository = new Mock<IChainRepository>();
			chainRepository.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Chain>(null));
			var validator = new ApiChainRequestModelValidator(chainRepository.Object);

			await validator.ValidateCreateAsync(new ApiChainRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByExternalId_Update_Exists()
		{
			Mock<IChainRepository> chainRepository = new Mock<IChainRepository>();
			chainRepository.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Chain>(new Chain()));
			var validator = new ApiChainRequestModelValidator(chainRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiChainRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByExternalId_Update_Not_Exists()
		{
			Mock<IChainRepository> chainRepository = new Mock<IChainRepository>();
			chainRepository.Setup(x => x.ByExternalId(It.IsAny<Guid>())).Returns(Task.FromResult<Chain>(null));
			var validator = new ApiChainRequestModelValidator(chainRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiChainRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ExternalId, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>f717c8e1a7e8b1d7f98bc4ce264d7f1e</Hash>
</Codenesium>*/