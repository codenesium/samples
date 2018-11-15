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
	[Trait("Table", "Team")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTeamServerRequestModelValidatorTest
	{
		public ApiTeamServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Team()));

			var validator = new ApiTeamServerRequestModelValidator(teamRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeamServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Team()));

			var validator = new ApiTeamServerRequestModelValidator(teamRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeamServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Team()));

			var validator = new ApiTeamServerRequestModelValidator(teamRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeamServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Team()));

			var validator = new ApiTeamServerRequestModelValidator(teamRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeamServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void OrganizationId_Create_Valid_Reference()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.OrganizationByOrganizationId(It.IsAny<int>())).Returns(Task.FromResult<Organization>(new Organization()));

			var validator = new ApiTeamServerRequestModelValidator(teamRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeamServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OrganizationId, 1);
		}

		[Fact]
		public async void OrganizationId_Create_Invalid_Reference()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.OrganizationByOrganizationId(It.IsAny<int>())).Returns(Task.FromResult<Organization>(null));

			var validator = new ApiTeamServerRequestModelValidator(teamRepository.Object);

			await validator.ValidateCreateAsync(new ApiTeamServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OrganizationId, 1);
		}

		[Fact]
		public async void OrganizationId_Update_Valid_Reference()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.OrganizationByOrganizationId(It.IsAny<int>())).Returns(Task.FromResult<Organization>(new Organization()));

			var validator = new ApiTeamServerRequestModelValidator(teamRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeamServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OrganizationId, 1);
		}

		[Fact]
		public async void OrganizationId_Update_Invalid_Reference()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.OrganizationByOrganizationId(It.IsAny<int>())).Returns(Task.FromResult<Organization>(null));

			var validator = new ApiTeamServerRequestModelValidator(teamRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTeamServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OrganizationId, 1);
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Team>(new Team()));
			var validator = new ApiTeamServerRequestModelValidator(teamRepository.Object);

			await validator.ValidateCreateAsync(new ApiTeamServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Team>(null));
			var validator = new ApiTeamServerRequestModelValidator(teamRepository.Object);

			await validator.ValidateCreateAsync(new ApiTeamServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Team>(new Team()));
			var validator = new ApiTeamServerRequestModelValidator(teamRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTeamServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Team>(null));
			var validator = new ApiTeamServerRequestModelValidator(teamRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTeamServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>d99fb0635356cdf97fc21812539c928a</Hash>
</Codenesium>*/