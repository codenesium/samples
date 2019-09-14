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
	[Trait("Table", "Organization")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiOrganizationServerRequestModelValidatorTest
	{
		public ApiOrganizationServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IOrganizationRepository> organizationRepository = new Mock<IOrganizationRepository>();
			organizationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Organization()));

			var validator = new ApiOrganizationServerRequestModelValidator(organizationRepository.Object);
			await validator.ValidateCreateAsync(new ApiOrganizationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IOrganizationRepository> organizationRepository = new Mock<IOrganizationRepository>();
			organizationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Organization()));

			var validator = new ApiOrganizationServerRequestModelValidator(organizationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOrganizationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IOrganizationRepository> organizationRepository = new Mock<IOrganizationRepository>();
			organizationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Organization()));

			var validator = new ApiOrganizationServerRequestModelValidator(organizationRepository.Object);
			await validator.ValidateCreateAsync(new ApiOrganizationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IOrganizationRepository> organizationRepository = new Mock<IOrganizationRepository>();
			organizationRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Organization()));

			var validator = new ApiOrganizationServerRequestModelValidator(organizationRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiOrganizationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IOrganizationRepository> organizationRepository = new Mock<IOrganizationRepository>();
			organizationRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Organization>(new Organization()));
			var validator = new ApiOrganizationServerRequestModelValidator(organizationRepository.Object);

			await validator.ValidateCreateAsync(new ApiOrganizationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IOrganizationRepository> organizationRepository = new Mock<IOrganizationRepository>();
			organizationRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Organization>(null));
			var validator = new ApiOrganizationServerRequestModelValidator(organizationRepository.Object);

			await validator.ValidateCreateAsync(new ApiOrganizationServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IOrganizationRepository> organizationRepository = new Mock<IOrganizationRepository>();
			organizationRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Organization>(new Organization()));
			var validator = new ApiOrganizationServerRequestModelValidator(organizationRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiOrganizationServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IOrganizationRepository> organizationRepository = new Mock<IOrganizationRepository>();
			organizationRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Organization>(null));
			var validator = new ApiOrganizationServerRequestModelValidator(organizationRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiOrganizationServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>8500db5727575036b4ac4588e60858f3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/