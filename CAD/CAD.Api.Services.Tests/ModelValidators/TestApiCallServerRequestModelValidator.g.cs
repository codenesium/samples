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
	[Trait("Table", "Call")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCallServerRequestModelValidatorTest
	{
		public ApiCallServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void AddressId_Create_Valid_Reference()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.AddressByAddressId(It.IsAny<int>())).Returns(Task.FromResult<Address>(new Address()));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.AddressId, 1);
		}

		[Fact]
		public async void AddressId_Create_Invalid_Reference()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.AddressByAddressId(It.IsAny<int>())).Returns(Task.FromResult<Address>(null));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);

			await validator.ValidateCreateAsync(new ApiCallServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AddressId, 1);
		}

		[Fact]
		public async void AddressId_Update_Valid_Reference()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.AddressByAddressId(It.IsAny<int>())).Returns(Task.FromResult<Address>(new Address()));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.AddressId, 1);
		}

		[Fact]
		public async void AddressId_Update_Invalid_Reference()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.AddressByAddressId(It.IsAny<int>())).Returns(Task.FromResult<Address>(null));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCallServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AddressId, 1);
		}

		[Fact]
		public async void CallDispositionId_Create_Valid_Reference()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.CallDispositionByCallDispositionId(It.IsAny<int>())).Returns(Task.FromResult<CallDisposition>(new CallDisposition()));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CallDispositionId, 1);
		}

		[Fact]
		public async void CallDispositionId_Create_Invalid_Reference()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.CallDispositionByCallDispositionId(It.IsAny<int>())).Returns(Task.FromResult<CallDisposition>(null));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);

			await validator.ValidateCreateAsync(new ApiCallServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CallDispositionId, 1);
		}

		[Fact]
		public async void CallDispositionId_Update_Valid_Reference()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.CallDispositionByCallDispositionId(It.IsAny<int>())).Returns(Task.FromResult<CallDisposition>(new CallDisposition()));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CallDispositionId, 1);
		}

		[Fact]
		public async void CallDispositionId_Update_Invalid_Reference()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.CallDispositionByCallDispositionId(It.IsAny<int>())).Returns(Task.FromResult<CallDisposition>(null));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCallServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CallDispositionId, 1);
		}

		[Fact]
		public async void CallStatusId_Create_Valid_Reference()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.CallStatusByCallStatusId(It.IsAny<int>())).Returns(Task.FromResult<CallStatus>(new CallStatus()));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CallStatusId, 1);
		}

		[Fact]
		public async void CallStatusId_Create_Invalid_Reference()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.CallStatusByCallStatusId(It.IsAny<int>())).Returns(Task.FromResult<CallStatus>(null));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);

			await validator.ValidateCreateAsync(new ApiCallServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CallStatusId, 1);
		}

		[Fact]
		public async void CallStatusId_Update_Valid_Reference()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.CallStatusByCallStatusId(It.IsAny<int>())).Returns(Task.FromResult<CallStatus>(new CallStatus()));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CallStatusId, 1);
		}

		[Fact]
		public async void CallStatusId_Update_Invalid_Reference()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.CallStatusByCallStatusId(It.IsAny<int>())).Returns(Task.FromResult<CallStatus>(null));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCallServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CallStatusId, 1);
		}

		[Fact]
		public async void CallString_Create_null()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Call()));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CallString, null as string);
		}

		[Fact]
		public async void CallString_Update_null()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Call()));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CallString, null as string);
		}

		[Fact]
		public async void CallString_Create_length()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Call()));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CallString, new string('A', 25));
		}

		[Fact]
		public async void CallString_Update_length()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Call()));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CallString, new string('A', 25));
		}

		[Fact]
		public async void CallTypeId_Create_Valid_Reference()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.CallTypeByCallTypeId(It.IsAny<int>())).Returns(Task.FromResult<CallType>(new CallType()));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);
			await validator.ValidateCreateAsync(new ApiCallServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CallTypeId, 1);
		}

		[Fact]
		public async void CallTypeId_Create_Invalid_Reference()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.CallTypeByCallTypeId(It.IsAny<int>())).Returns(Task.FromResult<CallType>(null));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);

			await validator.ValidateCreateAsync(new ApiCallServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CallTypeId, 1);
		}

		[Fact]
		public async void CallTypeId_Update_Valid_Reference()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.CallTypeByCallTypeId(It.IsAny<int>())).Returns(Task.FromResult<CallType>(new CallType()));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCallServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CallTypeId, 1);
		}

		[Fact]
		public async void CallTypeId_Update_Invalid_Reference()
		{
			Mock<ICallRepository> callRepository = new Mock<ICallRepository>();
			callRepository.Setup(x => x.CallTypeByCallTypeId(It.IsAny<int>())).Returns(Task.FromResult<CallType>(null));

			var validator = new ApiCallServerRequestModelValidator(callRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCallServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CallTypeId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>3cd65343e1a0c5fac2a3f0befb1961a0</Hash>
</Codenesium>*/