using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
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

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Unit")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiUnitServerRequestModelValidatorTest
	{
		public ApiUnitServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void CallSign_Create_length()
		{
			Mock<IUnitRepository> unitRepository = new Mock<IUnitRepository>();
			unitRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Unit()));

			var validator = new ApiUnitServerRequestModelValidator(unitRepository.Object);
			await validator.ValidateCreateAsync(new ApiUnitServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CallSign, new string('A', 129));
		}

		[Fact]
		public async void CallSign_Update_length()
		{
			Mock<IUnitRepository> unitRepository = new Mock<IUnitRepository>();
			unitRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Unit()));

			var validator = new ApiUnitServerRequestModelValidator(unitRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUnitServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CallSign, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>eecb30f678327388ba0fc189ec080cbf</Hash>
</Codenesium>*/