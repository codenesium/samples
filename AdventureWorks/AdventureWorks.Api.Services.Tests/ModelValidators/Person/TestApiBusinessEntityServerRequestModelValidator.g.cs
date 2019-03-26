using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "BusinessEntity")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiBusinessEntityServerRequestModelValidatorTest
	{
		public ApiBusinessEntityServerRequestModelValidatorTest()
		{
		}

		[Fact]
		private async void BeUniqueByRowguid_Create_Exists()
		{
			Mock<IBusinessEntityRepository> businessEntityRepository = new Mock<IBusinessEntityRepository>();
			businessEntityRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<BusinessEntity>(new BusinessEntity()));
			var validator = new ApiBusinessEntityServerRequestModelValidator(businessEntityRepository.Object);

			await validator.ValidateCreateAsync(new ApiBusinessEntityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Create_Not_Exists()
		{
			Mock<IBusinessEntityRepository> businessEntityRepository = new Mock<IBusinessEntityRepository>();
			businessEntityRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<BusinessEntity>(null));
			var validator = new ApiBusinessEntityServerRequestModelValidator(businessEntityRepository.Object);

			await validator.ValidateCreateAsync(new ApiBusinessEntityServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Update_Exists()
		{
			Mock<IBusinessEntityRepository> businessEntityRepository = new Mock<IBusinessEntityRepository>();
			businessEntityRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<BusinessEntity>(new BusinessEntity()));
			var validator = new ApiBusinessEntityServerRequestModelValidator(businessEntityRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiBusinessEntityServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Update_Not_Exists()
		{
			Mock<IBusinessEntityRepository> businessEntityRepository = new Mock<IBusinessEntityRepository>();
			businessEntityRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<BusinessEntity>(null));
			var validator = new ApiBusinessEntityServerRequestModelValidator(businessEntityRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiBusinessEntityServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>ce1b8bfa127b549252701d65c97b1a88</Hash>
</Codenesium>*/