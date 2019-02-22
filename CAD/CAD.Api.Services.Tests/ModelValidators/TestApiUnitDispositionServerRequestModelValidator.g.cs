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
	[Trait("Table", "UnitDisposition")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiUnitDispositionServerRequestModelValidatorTest
	{
		public ApiUnitDispositionServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IUnitDispositionRepository> unitDispositionRepository = new Mock<IUnitDispositionRepository>();
			unitDispositionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new UnitDisposition()));

			var validator = new ApiUnitDispositionServerRequestModelValidator(unitDispositionRepository.Object);
			await validator.ValidateCreateAsync(new ApiUnitDispositionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IUnitDispositionRepository> unitDispositionRepository = new Mock<IUnitDispositionRepository>();
			unitDispositionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new UnitDisposition()));

			var validator = new ApiUnitDispositionServerRequestModelValidator(unitDispositionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUnitDispositionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IUnitDispositionRepository> unitDispositionRepository = new Mock<IUnitDispositionRepository>();
			unitDispositionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new UnitDisposition()));

			var validator = new ApiUnitDispositionServerRequestModelValidator(unitDispositionRepository.Object);
			await validator.ValidateCreateAsync(new ApiUnitDispositionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IUnitDispositionRepository> unitDispositionRepository = new Mock<IUnitDispositionRepository>();
			unitDispositionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new UnitDisposition()));

			var validator = new ApiUnitDispositionServerRequestModelValidator(unitDispositionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUnitDispositionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>48912c8fa28509d85db94e7ec14d5af1</Hash>
</Codenesium>*/