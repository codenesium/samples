using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tenant")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTenantServerRequestModelValidatorTest
	{
		public ApiTenantServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
			tenantRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tenant()));

			var validator = new ApiTenantServerRequestModelValidator(tenantRepository.Object);
			await validator.ValidateCreateAsync(new ApiTenantServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
			tenantRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tenant()));

			var validator = new ApiTenantServerRequestModelValidator(tenantRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTenantServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
			tenantRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tenant()));

			var validator = new ApiTenantServerRequestModelValidator(tenantRepository.Object);
			await validator.ValidateCreateAsync(new ApiTenantServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ITenantRepository> tenantRepository = new Mock<ITenantRepository>();
			tenantRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tenant()));

			var validator = new ApiTenantServerRequestModelValidator(tenantRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTenantServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>4b5248c8bc7b6046099f9d6fc292443c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/