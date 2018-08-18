using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProjectGroup")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiProjectGroupRequestModelValidatorTest
	{
		public ApiProjectGroupRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IProjectGroupRepository> projectGroupRepository = new Mock<IProjectGroupRepository>();
			projectGroupRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectGroup()));

			var validator = new ApiProjectGroupRequestModelValidator(projectGroupRepository.Object);
			await validator.ValidateCreateAsync(new ApiProjectGroupRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IProjectGroupRepository> projectGroupRepository = new Mock<IProjectGroupRepository>();
			projectGroupRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new ProjectGroup()));

			var validator = new ApiProjectGroupRequestModelValidator(projectGroupRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiProjectGroupRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IProjectGroupRepository> projectGroupRepository = new Mock<IProjectGroupRepository>();
			projectGroupRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProjectGroup>(new ProjectGroup()));
			var validator = new ApiProjectGroupRequestModelValidator(projectGroupRepository.Object);

			await validator.ValidateCreateAsync(new ApiProjectGroupRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IProjectGroupRepository> projectGroupRepository = new Mock<IProjectGroupRepository>();
			projectGroupRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProjectGroup>(null));
			var validator = new ApiProjectGroupRequestModelValidator(projectGroupRepository.Object);

			await validator.ValidateCreateAsync(new ApiProjectGroupRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IProjectGroupRepository> projectGroupRepository = new Mock<IProjectGroupRepository>();
			projectGroupRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProjectGroup>(new ProjectGroup()));
			var validator = new ApiProjectGroupRequestModelValidator(projectGroupRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiProjectGroupRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IProjectGroupRepository> projectGroupRepository = new Mock<IProjectGroupRepository>();
			projectGroupRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<ProjectGroup>(null));
			var validator = new ApiProjectGroupRequestModelValidator(projectGroupRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiProjectGroupRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>00c84fbaaad2639764c54fb00ecb0a66</Hash>
</Codenesium>*/