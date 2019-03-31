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
	[Trait("Table", "EventTeacher")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiEventTeacherServerRequestModelValidatorTest
	{
		public ApiEventTeacherServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void EventId_Create_Valid_Reference()
		{
			Mock<IEventTeacherRepository> eventTeacherRepository = new Mock<IEventTeacherRepository>();
			eventTeacherRepository.Setup(x => x.EventByEventId(It.IsAny<int>())).Returns(Task.FromResult<Event>(new Event()));

			var validator = new ApiEventTeacherServerRequestModelValidator(eventTeacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventTeacherServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EventId, 1);
		}

		[Fact]
		public async void EventId_Create_Invalid_Reference()
		{
			Mock<IEventTeacherRepository> eventTeacherRepository = new Mock<IEventTeacherRepository>();
			eventTeacherRepository.Setup(x => x.EventByEventId(It.IsAny<int>())).Returns(Task.FromResult<Event>(null));

			var validator = new ApiEventTeacherServerRequestModelValidator(eventTeacherRepository.Object);

			await validator.ValidateCreateAsync(new ApiEventTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EventId, 1);
		}

		[Fact]
		public async void EventId_Update_Valid_Reference()
		{
			Mock<IEventTeacherRepository> eventTeacherRepository = new Mock<IEventTeacherRepository>();
			eventTeacherRepository.Setup(x => x.EventByEventId(It.IsAny<int>())).Returns(Task.FromResult<Event>(new Event()));

			var validator = new ApiEventTeacherServerRequestModelValidator(eventTeacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventTeacherServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.EventId, 1);
		}

		[Fact]
		public async void EventId_Update_Invalid_Reference()
		{
			Mock<IEventTeacherRepository> eventTeacherRepository = new Mock<IEventTeacherRepository>();
			eventTeacherRepository.Setup(x => x.EventByEventId(It.IsAny<int>())).Returns(Task.FromResult<Event>(null));

			var validator = new ApiEventTeacherServerRequestModelValidator(eventTeacherRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiEventTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EventId, 1);
		}

		[Fact]
		public async void TeacherId_Create_Valid_Reference()
		{
			Mock<IEventTeacherRepository> eventTeacherRepository = new Mock<IEventTeacherRepository>();
			eventTeacherRepository.Setup(x => x.TeacherByTeacherId(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(new Teacher()));

			var validator = new ApiEventTeacherServerRequestModelValidator(eventTeacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventTeacherServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Create_Invalid_Reference()
		{
			Mock<IEventTeacherRepository> eventTeacherRepository = new Mock<IEventTeacherRepository>();
			eventTeacherRepository.Setup(x => x.TeacherByTeacherId(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));

			var validator = new ApiEventTeacherServerRequestModelValidator(eventTeacherRepository.Object);

			await validator.ValidateCreateAsync(new ApiEventTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Update_Valid_Reference()
		{
			Mock<IEventTeacherRepository> eventTeacherRepository = new Mock<IEventTeacherRepository>();
			eventTeacherRepository.Setup(x => x.TeacherByTeacherId(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(new Teacher()));

			var validator = new ApiEventTeacherServerRequestModelValidator(eventTeacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventTeacherServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Update_Invalid_Reference()
		{
			Mock<IEventTeacherRepository> eventTeacherRepository = new Mock<IEventTeacherRepository>();
			eventTeacherRepository.Setup(x => x.TeacherByTeacherId(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));

			var validator = new ApiEventTeacherServerRequestModelValidator(eventTeacherRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiEventTeacherServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>6692cbafbd60902978f12cdd80015d82</Hash>
</Codenesium>*/