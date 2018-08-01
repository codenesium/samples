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
	[Trait("Table", "TenantVariable")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTenantVariableRequestModelValidatorTest
	{
		public ApiTenantVariableRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void EnvironmentId_Create_length()
		{
			Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
			tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

			var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTenantVariableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
		}

		[Fact]
		public async void EnvironmentId_Update_length()
		{
			Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
			tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

			var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiTenantVariableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, new string('A', 51));
		}

		[Fact]
		public async void OwnerId_Create_length()
		{
			Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
			tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

			var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTenantVariableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OwnerId, new string('A', 51));
		}

		[Fact]
		public async void OwnerId_Update_length()
		{
			Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
			tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

			var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiTenantVariableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OwnerId, new string('A', 51));
		}

		[Fact]
		public async void TenantId_Create_length()
		{
			Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
			tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

			var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTenantVariableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
		}

		[Fact]
		public async void TenantId_Update_length()
		{
			Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
			tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

			var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiTenantVariableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TenantId, new string('A', 51));
		}

		[Fact]
		public async void VariableTemplateId_Create_length()
		{
			Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
			tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

			var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTenantVariableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VariableTemplateId, new string('A', 51));
		}

		[Fact]
		public async void VariableTemplateId_Update_length()
		{
			Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
			tenantVariableRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new TenantVariable()));

			var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiTenantVariableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VariableTemplateId, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByTenantIdOwnerIdEnvironmentIdVariableTemplateId_Create_Exists()
		{
			Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
			tenantVariableRepository.Setup(x => x.ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<TenantVariable>(new TenantVariable()));
			var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

			await validator.ValidateCreateAsync(new ApiTenantVariableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, "A");
		}

		[Fact]
		private async void BeUniqueByTenantIdOwnerIdEnvironmentIdVariableTemplateId_Create_Not_Exists()
		{
			Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
			tenantVariableRepository.Setup(x => x.ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<TenantVariable>(null));
			var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

			await validator.ValidateCreateAsync(new ApiTenantVariableRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EnvironmentId, "A");
		}

		[Fact]
		private async void BeUniqueByTenantIdOwnerIdEnvironmentIdVariableTemplateId_Update_Exists()
		{
			Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
			tenantVariableRepository.Setup(x => x.ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<TenantVariable>(new TenantVariable()));
			var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiTenantVariableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EnvironmentId, "A");
		}

		[Fact]
		private async void BeUniqueByTenantIdOwnerIdEnvironmentIdVariableTemplateId_Update_Not_Exists()
		{
			Mock<ITenantVariableRepository> tenantVariableRepository = new Mock<ITenantVariableRepository>();
			tenantVariableRepository.Setup(x => x.ByTenantIdOwnerIdEnvironmentIdVariableTemplateId(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<TenantVariable>(null));
			var validator = new ApiTenantVariableRequestModelValidator(tenantVariableRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiTenantVariableRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EnvironmentId, "A");
		}
	}
}

/*<Codenesium>
    <Hash>f52eab305c937f14171b814827a78334</Hash>
</Codenesium>*/