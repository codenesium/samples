using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tenant")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTenantRequestModelValidatorTest
	{
		public ApiTenantRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
			tenantRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tenant()));

			var validator = new ApiTenantRequestModelValidator(tenantRepository.Object);
			await validator.ValidateCreateAsync(new ApiTenantRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
			tenantRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tenant()));

			var validator = new ApiTenantRequestModelValidator(tenantRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTenantRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
			tenantRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tenant()));

			var validator = new ApiTenantRequestModelValidator(tenantRepository.Object);
			await validator.ValidateCreateAsync(new ApiTenantRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
			tenantRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tenant()));

			var validator = new ApiTenantRequestModelValidator(tenantRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTenantRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>a2139366f00ce33aab6fb55f2dd4ea38</Hash>
</Codenesium>*/