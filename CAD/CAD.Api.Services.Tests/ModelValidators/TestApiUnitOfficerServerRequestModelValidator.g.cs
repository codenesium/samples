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
	[Trait("Table", "UnitOfficer")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiUnitOfficerServerRequestModelValidatorTest
	{
		public ApiUnitOfficerServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void OfficerId_Create_Valid_Reference()
		{
			Mock<IUnitOfficerRepository> unitOfficerRepository = new Mock<IUnitOfficerRepository>();
			unitOfficerRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(new Officer()));

			var validator = new ApiUnitOfficerServerRequestModelValidator(unitOfficerRepository.Object);
			await validator.ValidateCreateAsync(new ApiUnitOfficerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Create_Invalid_Reference()
		{
			Mock<IUnitOfficerRepository> unitOfficerRepository = new Mock<IUnitOfficerRepository>();
			unitOfficerRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(null));

			var validator = new ApiUnitOfficerServerRequestModelValidator(unitOfficerRepository.Object);

			await validator.ValidateCreateAsync(new ApiUnitOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Update_Valid_Reference()
		{
			Mock<IUnitOfficerRepository> unitOfficerRepository = new Mock<IUnitOfficerRepository>();
			unitOfficerRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(new Officer()));

			var validator = new ApiUnitOfficerServerRequestModelValidator(unitOfficerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUnitOfficerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Update_Invalid_Reference()
		{
			Mock<IUnitOfficerRepository> unitOfficerRepository = new Mock<IUnitOfficerRepository>();
			unitOfficerRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(null));

			var validator = new ApiUnitOfficerServerRequestModelValidator(unitOfficerRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiUnitOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void UnitId_Create_Valid_Reference()
		{
			Mock<IUnitOfficerRepository> unitOfficerRepository = new Mock<IUnitOfficerRepository>();
			unitOfficerRepository.Setup(x => x.UnitByUnitId(It.IsAny<int>())).Returns(Task.FromResult<Unit>(new Unit()));

			var validator = new ApiUnitOfficerServerRequestModelValidator(unitOfficerRepository.Object);
			await validator.ValidateCreateAsync(new ApiUnitOfficerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UnitId, 1);
		}

		[Fact]
		public async void UnitId_Create_Invalid_Reference()
		{
			Mock<IUnitOfficerRepository> unitOfficerRepository = new Mock<IUnitOfficerRepository>();
			unitOfficerRepository.Setup(x => x.UnitByUnitId(It.IsAny<int>())).Returns(Task.FromResult<Unit>(null));

			var validator = new ApiUnitOfficerServerRequestModelValidator(unitOfficerRepository.Object);

			await validator.ValidateCreateAsync(new ApiUnitOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UnitId, 1);
		}

		[Fact]
		public async void UnitId_Update_Valid_Reference()
		{
			Mock<IUnitOfficerRepository> unitOfficerRepository = new Mock<IUnitOfficerRepository>();
			unitOfficerRepository.Setup(x => x.UnitByUnitId(It.IsAny<int>())).Returns(Task.FromResult<Unit>(new Unit()));

			var validator = new ApiUnitOfficerServerRequestModelValidator(unitOfficerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUnitOfficerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UnitId, 1);
		}

		[Fact]
		public async void UnitId_Update_Invalid_Reference()
		{
			Mock<IUnitOfficerRepository> unitOfficerRepository = new Mock<IUnitOfficerRepository>();
			unitOfficerRepository.Setup(x => x.UnitByUnitId(It.IsAny<int>())).Returns(Task.FromResult<Unit>(null));

			var validator = new ApiUnitOfficerServerRequestModelValidator(unitOfficerRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiUnitOfficerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UnitId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>459dd440211620f65d2ff5eb24e8af8d</Hash>
</Codenesium>*/