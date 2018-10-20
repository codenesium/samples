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
	public partial class ApiEventTeacherRequestModelValidatorTest
	{
		public ApiEventTeacherRequestModelValidatorTest()
		{
		}

		// table.Columns[i].GetReferenceTable().AppTableName= Teacher
		[Fact]
		public async void TeacherId_Create_Valid_Reference()
		{
			Mock<IEventTeacherRepository> eventTeacherRepository = new Mock<IEventTeacherRepository>();
			eventTeacherRepository.Setup(x => x.TeacherByTeacherId(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(new Teacher()));

			var validator = new ApiEventTeacherRequestModelValidator(eventTeacherRepository.Object);
			await validator.ValidateCreateAsync(new ApiEventTeacherRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Create_Invalid_Reference()
		{
			Mock<IEventTeacherRepository> eventTeacherRepository = new Mock<IEventTeacherRepository>();
			eventTeacherRepository.Setup(x => x.TeacherByTeacherId(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));

			var validator = new ApiEventTeacherRequestModelValidator(eventTeacherRepository.Object);

			await validator.ValidateCreateAsync(new ApiEventTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Update_Valid_Reference()
		{
			Mock<IEventTeacherRepository> eventTeacherRepository = new Mock<IEventTeacherRepository>();
			eventTeacherRepository.Setup(x => x.TeacherByTeacherId(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(new Teacher()));

			var validator = new ApiEventTeacherRequestModelValidator(eventTeacherRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiEventTeacherRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TeacherId, 1);
		}

		[Fact]
		public async void TeacherId_Update_Invalid_Reference()
		{
			Mock<IEventTeacherRepository> eventTeacherRepository = new Mock<IEventTeacherRepository>();
			eventTeacherRepository.Setup(x => x.TeacherByTeacherId(It.IsAny<int>())).Returns(Task.FromResult<Teacher>(null));

			var validator = new ApiEventTeacherRequestModelValidator(eventTeacherRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiEventTeacherRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TeacherId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>2b6839bb755488cd73e3502c73d75456</Hash>
</Codenesium>*/