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
    <Hash>aa05d7c8c4ef6cc8c3d4caa7d399363e</Hash>
</Codenesium>*/