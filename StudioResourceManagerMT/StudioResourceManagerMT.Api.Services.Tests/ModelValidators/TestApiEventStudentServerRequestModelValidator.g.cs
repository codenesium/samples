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
	[Trait("Table", "EventStudent")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiEventStudentServerRequestModelValidatorTest
	{
		public ApiEventStudentServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void EventId_Create_Valid_Reference()
		{
			Mock<IEventStudentRepository> eventStudentRepository = new Mock<IEventStudentRepository>();
			eventStudentRepository.Setup(x => x.EventByEventId(It.IsAny<int>())).Returns(Task.FromResult<Event>(new Event()));

			var validator = new ApiEventStudentServerRequestModelValidator(eventStudentRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventStudentServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EventId, 1);
		}

		[Fact]
		public async void EventId_Create_Invalid_Reference()
		{
			Mock<IEventStudentRepository> eventStudentRepository = new Mock<IEventStudentRepository>();
			eventStudentRepository.Setup(x => x.EventByEventId(It.IsAny<int>())).Returns(Task.FromResult<Event>(null));

			var validator = new ApiEventStudentServerRequestModelValidator(eventStudentRepository.Object);

			await validator.ValidateCreateAsync(new ApiEventStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EventId, 1);
		}

		[Fact]
		public async void EventId_Update_Valid_Reference()
		{
			Mock<IEventStudentRepository> eventStudentRepository = new Mock<IEventStudentRepository>();
			eventStudentRepository.Setup(x => x.EventByEventId(It.IsAny<int>())).Returns(Task.FromResult<Event>(new Event()));

			var validator = new ApiEventStudentServerRequestModelValidator(eventStudentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventStudentServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EventId, 1);
		}

		[Fact]
		public async void EventId_Update_Invalid_Reference()
		{
			Mock<IEventStudentRepository> eventStudentRepository = new Mock<IEventStudentRepository>();
			eventStudentRepository.Setup(x => x.EventByEventId(It.IsAny<int>())).Returns(Task.FromResult<Event>(null));

			var validator = new ApiEventStudentServerRequestModelValidator(eventStudentRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiEventStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EventId, 1);
		}

		[Fact]
		public async void StudentId_Create_Valid_Reference()
		{
			Mock<IEventStudentRepository> eventStudentRepository = new Mock<IEventStudentRepository>();
			eventStudentRepository.Setup(x => x.StudentByStudentId(It.IsAny<int>())).Returns(Task.FromResult<Student>(new Student()));

			var validator = new ApiEventStudentServerRequestModelValidator(eventStudentRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventStudentServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudentId, 1);
		}

		[Fact]
		public async void StudentId_Create_Invalid_Reference()
		{
			Mock<IEventStudentRepository> eventStudentRepository = new Mock<IEventStudentRepository>();
			eventStudentRepository.Setup(x => x.StudentByStudentId(It.IsAny<int>())).Returns(Task.FromResult<Student>(null));

			var validator = new ApiEventStudentServerRequestModelValidator(eventStudentRepository.Object);

			await validator.ValidateCreateAsync(new ApiEventStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudentId, 1);
		}

		[Fact]
		public async void StudentId_Update_Valid_Reference()
		{
			Mock<IEventStudentRepository> eventStudentRepository = new Mock<IEventStudentRepository>();
			eventStudentRepository.Setup(x => x.StudentByStudentId(It.IsAny<int>())).Returns(Task.FromResult<Student>(new Student()));

			var validator = new ApiEventStudentServerRequestModelValidator(eventStudentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventStudentServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudentId, 1);
		}

		[Fact]
		public async void StudentId_Update_Invalid_Reference()
		{
			Mock<IEventStudentRepository> eventStudentRepository = new Mock<IEventStudentRepository>();
			eventStudentRepository.Setup(x => x.StudentByStudentId(It.IsAny<int>())).Returns(Task.FromResult<Student>(null));

			var validator = new ApiEventStudentServerRequestModelValidator(eventStudentRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiEventStudentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudentId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>83a71917cbbad538dcef0ddb3a5cd17f</Hash>
</Codenesium>*/