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
	public partial class ApiTeamRequestModelValidatorTest
	{
		public ApiTeamRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Team()));

			var validator = new ApiTeamRequestModelValidator(teamRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeamRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Team()));

			var validator = new ApiTeamRequestModelValidator(teamRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeamRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void OrganizationId_Create_Valid_Reference()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.GetOrganization(It.IsAny<int>())).Returns(Task.FromResult<Organization>(new Organization()));

			var validator = new ApiTeamRequestModelValidator(teamRepository.Object);
			await validator.ValidateCreateAsync(new ApiTeamRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OrganizationId, 1);
		}

		[Fact]
		public async void OrganizationId_Create_Invalid_Reference()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.GetOrganization(It.IsAny<int>())).Returns(Task.FromResult<Organization>(null));

			var validator = new ApiTeamRequestModelValidator(teamRepository.Object);

			await validator.ValidateCreateAsync(new ApiTeamRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OrganizationId, 1);
		}

		[Fact]
		public async void OrganizationId_Update_Valid_Reference()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.GetOrganization(It.IsAny<int>())).Returns(Task.FromResult<Organization>(new Organization()));

			var validator = new ApiTeamRequestModelValidator(teamRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTeamRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OrganizationId, 1);
		}

		[Fact]
		public async void OrganizationId_Update_Invalid_Reference()
		{
			Mock<ITeamRepository> teamRepository = new Mock<ITeamRepository>();
			teamRepository.Setup(x => x.GetOrganization(It.IsAny<int>())).Returns(Task.FromResult<Organization>(null));

			var validator = new ApiTeamRequestModelValidator(teamRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTeamRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OrganizationId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>bdae186351f58ed9a6709c44a7a3a70b</Hash>
</Codenesium>*/