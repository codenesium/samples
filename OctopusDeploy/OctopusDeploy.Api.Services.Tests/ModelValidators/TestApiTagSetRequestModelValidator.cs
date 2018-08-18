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
	[Trait("Table", "TagSet")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTagSetRequestModelValidatorTest
	{
		public ApiTagSetRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ITagSetRepository> tagSetRepository = new Mock<ITagSetRepository>();
			tagSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TagSet()));

			var validator = new ApiTagSetRequestModelValidator(tagSetRepository.Object);
			await validator.ValidateCreateAsync(new ApiTagSetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ITagSetRepository> tagSetRepository = new Mock<ITagSetRepository>();
			tagSetRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TagSet()));

			var validator = new ApiTagSetRequestModelValidator(tagSetRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiTagSetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<ITagSetRepository> tagSetRepository = new Mock<ITagSetRepository>();
			tagSetRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<TagSet>(new TagSet()));
			var validator = new ApiTagSetRequestModelValidator(tagSetRepository.Object);

			await validator.ValidateCreateAsync(new ApiTagSetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<ITagSetRepository> tagSetRepository = new Mock<ITagSetRepository>();
			tagSetRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<TagSet>(null));
			var validator = new ApiTagSetRequestModelValidator(tagSetRepository.Object);

			await validator.ValidateCreateAsync(new ApiTagSetRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<ITagSetRepository> tagSetRepository = new Mock<ITagSetRepository>();
			tagSetRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<TagSet>(new TagSet()));
			var validator = new ApiTagSetRequestModelValidator(tagSetRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiTagSetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<ITagSetRepository> tagSetRepository = new Mock<ITagSetRepository>();
			tagSetRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<TagSet>(null));
			var validator = new ApiTagSetRequestModelValidator(tagSetRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiTagSetRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>c13580d1e48937d09994126ab7387c94</Hash>
</Codenesium>*/