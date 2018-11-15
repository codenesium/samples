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
	[Trait("Table", "Shift")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiShiftServerRequestModelValidatorTest
	{
		public ApiShiftServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
			shiftRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Shift()));

			var validator = new ApiShiftServerRequestModelValidator(shiftRepository.Object);
			await validator.ValidateCreateAsync(new ApiShiftServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
			shiftRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Shift()));

			var validator = new ApiShiftServerRequestModelValidator(shiftRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiShiftServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
			shiftRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Shift()));

			var validator = new ApiShiftServerRequestModelValidator(shiftRepository.Object);
			await validator.ValidateCreateAsync(new ApiShiftServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
			shiftRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Shift()));

			var validator = new ApiShiftServerRequestModelValidator(shiftRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiShiftServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByStartTimeEndTime_Create_Exists()
		{
			Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
			shiftRepository.Setup(x => x.ByStartTimeEndTime(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(Task.FromResult<Shift>(new Shift()));
			var validator = new ApiShiftServerRequestModelValidator(shiftRepository.Object);

			await validator.ValidateCreateAsync(new ApiShiftServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EndTime, TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		private async void BeUniqueByStartTimeEndTime_Create_Not_Exists()
		{
			Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
			shiftRepository.Setup(x => x.ByStartTimeEndTime(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(Task.FromResult<Shift>(null));
			var validator = new ApiShiftServerRequestModelValidator(shiftRepository.Object);

			await validator.ValidateCreateAsync(new ApiShiftServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EndTime, TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		private async void BeUniqueByStartTimeEndTime_Update_Exists()
		{
			Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
			shiftRepository.Setup(x => x.ByStartTimeEndTime(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(Task.FromResult<Shift>(new Shift()));
			var validator = new ApiShiftServerRequestModelValidator(shiftRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiShiftServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EndTime, TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		private async void BeUniqueByStartTimeEndTime_Update_Not_Exists()
		{
			Mock<IShiftRepository> shiftRepository = new Mock<IShiftRepository>();
			shiftRepository.Setup(x => x.ByStartTimeEndTime(It.IsAny<TimeSpan>(), It.IsAny<TimeSpan>())).Returns(Task.FromResult<Shift>(null));
			var validator = new ApiShiftServerRequestModelValidator(shiftRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiShiftServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EndTime, TimeSpan.Parse("01:00:00"));
		}
	}
}

/*<Codenesium>
    <Hash>c8a5c6e043204531d18166dcda3fb348</Hash>
</Codenesium>*/