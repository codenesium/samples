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
	[Trait("Table", "CallAssignment")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCallAssignmentServerRequestModelValidatorTest
	{
		public ApiCallAssignmentServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void CallId_Create_Valid_Reference()
		{
			Mock<ICallAssignmentRepository> callAssignmentRepository = new Mock<ICallAssignmentRepository>();
			callAssignmentRepository.Setup(x => x.CallByCallId(It.IsAny<int>())).Returns(Task.FromResult<Call>(new Call()));

			var validator = new ApiCallAssignmentServerRequestModelValidator(callAssignmentRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallAssignmentServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CallId, 1);
		}

		[Fact]
		public async void CallId_Create_Invalid_Reference()
		{
			Mock<ICallAssignmentRepository> callAssignmentRepository = new Mock<ICallAssignmentRepository>();
			callAssignmentRepository.Setup(x => x.CallByCallId(It.IsAny<int>())).Returns(Task.FromResult<Call>(null));

			var validator = new ApiCallAssignmentServerRequestModelValidator(callAssignmentRepository.Object);

			await validator.ValidateCreateAsync(new ApiCallAssignmentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CallId, 1);
		}

		[Fact]
		public async void CallId_Update_Valid_Reference()
		{
			Mock<ICallAssignmentRepository> callAssignmentRepository = new Mock<ICallAssignmentRepository>();
			callAssignmentRepository.Setup(x => x.CallByCallId(It.IsAny<int>())).Returns(Task.FromResult<Call>(new Call()));

			var validator = new ApiCallAssignmentServerRequestModelValidator(callAssignmentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallAssignmentServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CallId, 1);
		}

		[Fact]
		public async void CallId_Update_Invalid_Reference()
		{
			Mock<ICallAssignmentRepository> callAssignmentRepository = new Mock<ICallAssignmentRepository>();
			callAssignmentRepository.Setup(x => x.CallByCallId(It.IsAny<int>())).Returns(Task.FromResult<Call>(null));

			var validator = new ApiCallAssignmentServerRequestModelValidator(callAssignmentRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCallAssignmentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CallId, 1);
		}

		[Fact]
		public async void UnitId_Create_Valid_Reference()
		{
			Mock<ICallAssignmentRepository> callAssignmentRepository = new Mock<ICallAssignmentRepository>();
			callAssignmentRepository.Setup(x => x.UnitByUnitId(It.IsAny<int>())).Returns(Task.FromResult<Unit>(new Unit()));

			var validator = new ApiCallAssignmentServerRequestModelValidator(callAssignmentRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallAssignmentServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UnitId, 1);
		}

		[Fact]
		public async void UnitId_Create_Invalid_Reference()
		{
			Mock<ICallAssignmentRepository> callAssignmentRepository = new Mock<ICallAssignmentRepository>();
			callAssignmentRepository.Setup(x => x.UnitByUnitId(It.IsAny<int>())).Returns(Task.FromResult<Unit>(null));

			var validator = new ApiCallAssignmentServerRequestModelValidator(callAssignmentRepository.Object);

			await validator.ValidateCreateAsync(new ApiCallAssignmentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UnitId, 1);
		}

		[Fact]
		public async void UnitId_Update_Valid_Reference()
		{
			Mock<ICallAssignmentRepository> callAssignmentRepository = new Mock<ICallAssignmentRepository>();
			callAssignmentRepository.Setup(x => x.UnitByUnitId(It.IsAny<int>())).Returns(Task.FromResult<Unit>(new Unit()));

			var validator = new ApiCallAssignmentServerRequestModelValidator(callAssignmentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallAssignmentServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UnitId, 1);
		}

		[Fact]
		public async void UnitId_Update_Invalid_Reference()
		{
			Mock<ICallAssignmentRepository> callAssignmentRepository = new Mock<ICallAssignmentRepository>();
			callAssignmentRepository.Setup(x => x.UnitByUnitId(It.IsAny<int>())).Returns(Task.FromResult<Unit>(null));

			var validator = new ApiCallAssignmentServerRequestModelValidator(callAssignmentRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCallAssignmentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UnitId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>692067f4ac3bc0ad31ca51a9ac2dcfca</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/