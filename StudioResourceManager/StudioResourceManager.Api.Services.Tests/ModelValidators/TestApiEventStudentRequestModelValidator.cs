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
	[Trait("Table", "EventStudent")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiEventStudentRequestModelValidatorTest
	{
		public ApiEventStudentRequestModelValidatorTest()
		{
		}

		// table.Columns[i].GetReferenceTable().AppTableName= Student
		[Fact]
		public async void StudentId_Create_Valid_Reference()
		{
			Mock<IEventStudentRepository> eventStudentRepository = new Mock<IEventStudentRepository>();
			eventStudentRepository.Setup(x => x.StudentByStudentId(It.IsAny<int>())).Returns(Task.FromResult<Student>(new Student()));

			var validator = new ApiEventStudentRequestModelValidator(eventStudentRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventStudentRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudentId, 1);
		}

		[Fact]
		public async void StudentId_Create_Invalid_Reference()
		{
			Mock<IEventStudentRepository> eventStudentRepository = new Mock<IEventStudentRepository>();
			eventStudentRepository.Setup(x => x.StudentByStudentId(It.IsAny<int>())).Returns(Task.FromResult<Student>(null));

			var validator = new ApiEventStudentRequestModelValidator(eventStudentRepository.Object);

			await validator.ValidateCreateAsync(new ApiEventStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudentId, 1);
		}

		[Fact]
		public async void StudentId_Update_Valid_Reference()
		{
			Mock<IEventStudentRepository> eventStudentRepository = new Mock<IEventStudentRepository>();
			eventStudentRepository.Setup(x => x.StudentByStudentId(It.IsAny<int>())).Returns(Task.FromResult<Student>(new Student()));

			var validator = new ApiEventStudentRequestModelValidator(eventStudentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventStudentRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudentId, 1);
		}

		[Fact]
		public async void StudentId_Update_Invalid_Reference()
		{
			Mock<IEventStudentRepository> eventStudentRepository = new Mock<IEventStudentRepository>();
			eventStudentRepository.Setup(x => x.StudentByStudentId(It.IsAny<int>())).Returns(Task.FromResult<Student>(null));

			var validator = new ApiEventStudentRequestModelValidator(eventStudentRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiEventStudentRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudentId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>da7c20c6385506d69ab5b551e17da004</Hash>
</Codenesium>*/