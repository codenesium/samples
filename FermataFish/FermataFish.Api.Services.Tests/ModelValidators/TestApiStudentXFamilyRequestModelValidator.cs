using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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

namespace FermataFishNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "StudentXFamily")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiStudentXFamilyRequestModelValidatorTest
	{
		public ApiStudentXFamilyRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void FamilyId_Create_Valid_Reference()
		{
			Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
			studentXFamilyRepository.Setup(x => x.GetFamily(It.IsAny<int>())).Returns(Task.FromResult<Family>(new Family()));

			var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentXFamilyRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.FamilyId, 1);
		}

		[Fact]
		public async void FamilyId_Create_Invalid_Reference()
		{
			Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
			studentXFamilyRepository.Setup(x => x.GetFamily(It.IsAny<int>())).Returns(Task.FromResult<Family>(null));

			var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);

			await validator.ValidateCreateAsync(new ApiStudentXFamilyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FamilyId, 1);
		}

		[Fact]
		public async void FamilyId_Update_Valid_Reference()
		{
			Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
			studentXFamilyRepository.Setup(x => x.GetFamily(It.IsAny<int>())).Returns(Task.FromResult<Family>(new Family()));

			var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentXFamilyRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.FamilyId, 1);
		}

		[Fact]
		public async void FamilyId_Update_Invalid_Reference()
		{
			Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
			studentXFamilyRepository.Setup(x => x.GetFamily(It.IsAny<int>())).Returns(Task.FromResult<Family>(null));

			var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiStudentXFamilyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FamilyId, 1);
		}

		[Fact]
		public async void StudentId_Create_Valid_Reference()
		{
			Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
			studentXFamilyRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(new Student()));

			var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentXFamilyRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudentId, 1);
		}

		[Fact]
		public async void StudentId_Create_Invalid_Reference()
		{
			Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
			studentXFamilyRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(null));

			var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);

			await validator.ValidateCreateAsync(new ApiStudentXFamilyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudentId, 1);
		}

		[Fact]
		public async void StudentId_Update_Valid_Reference()
		{
			Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
			studentXFamilyRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(new Student()));

			var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentXFamilyRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudentId, 1);
		}

		[Fact]
		public async void StudentId_Update_Invalid_Reference()
		{
			Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
			studentXFamilyRepository.Setup(x => x.GetStudent(It.IsAny<int>())).Returns(Task.FromResult<Student>(null));

			var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiStudentXFamilyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudentId, 1);
		}

		[Fact]
		public async void StudioId_Create_Valid_Reference()
		{
			Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
			studentXFamilyRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

			var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);
			await validator.ValidateCreateAsync(new ApiStudentXFamilyRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Create_Invalid_Reference()
		{
			Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
			studentXFamilyRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

			var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);

			await validator.ValidateCreateAsync(new ApiStudentXFamilyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Update_Valid_Reference()
		{
			Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
			studentXFamilyRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(new Studio()));

			var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiStudentXFamilyRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StudioId, 1);
		}

		[Fact]
		public async void StudioId_Update_Invalid_Reference()
		{
			Mock<IStudentXFamilyRepository> studentXFamilyRepository = new Mock<IStudentXFamilyRepository>();
			studentXFamilyRepository.Setup(x => x.GetStudio(It.IsAny<int>())).Returns(Task.FromResult<Studio>(null));

			var validator = new ApiStudentXFamilyRequestModelValidator(studentXFamilyRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiStudentXFamilyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StudioId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>13a9689f3f8e377667a67f9c1f0d8395</Hash>
</Codenesium>*/