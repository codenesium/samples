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
	[Trait("Table", "Note")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiNoteServerRequestModelValidatorTest
	{
		public ApiNoteServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void CallId_Create_Valid_Reference()
		{
			Mock<INoteRepository> noteRepository = new Mock<INoteRepository>();
			noteRepository.Setup(x => x.CallByCallId(It.IsAny<int>())).Returns(Task.FromResult<Call>(new Call()));

			var validator = new ApiNoteServerRequestModelValidator(noteRepository.Object);
			await validator.ValidateCreateAsync(new ApiNoteServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CallId, 1);
		}

		[Fact]
		public async void CallId_Create_Invalid_Reference()
		{
			Mock<INoteRepository> noteRepository = new Mock<INoteRepository>();
			noteRepository.Setup(x => x.CallByCallId(It.IsAny<int>())).Returns(Task.FromResult<Call>(null));

			var validator = new ApiNoteServerRequestModelValidator(noteRepository.Object);

			await validator.ValidateCreateAsync(new ApiNoteServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CallId, 1);
		}

		[Fact]
		public async void CallId_Update_Valid_Reference()
		{
			Mock<INoteRepository> noteRepository = new Mock<INoteRepository>();
			noteRepository.Setup(x => x.CallByCallId(It.IsAny<int>())).Returns(Task.FromResult<Call>(new Call()));

			var validator = new ApiNoteServerRequestModelValidator(noteRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiNoteServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CallId, 1);
		}

		[Fact]
		public async void CallId_Update_Invalid_Reference()
		{
			Mock<INoteRepository> noteRepository = new Mock<INoteRepository>();
			noteRepository.Setup(x => x.CallByCallId(It.IsAny<int>())).Returns(Task.FromResult<Call>(null));

			var validator = new ApiNoteServerRequestModelValidator(noteRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiNoteServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CallId, 1);
		}

		[Fact]
		public async void NoteText_Create_null()
		{
			Mock<INoteRepository> noteRepository = new Mock<INoteRepository>();
			noteRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Note()));

			var validator = new ApiNoteServerRequestModelValidator(noteRepository.Object);
			await validator.ValidateCreateAsync(new ApiNoteServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.NoteText, null as string);
		}

		[Fact]
		public async void NoteText_Update_null()
		{
			Mock<INoteRepository> noteRepository = new Mock<INoteRepository>();
			noteRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Note()));

			var validator = new ApiNoteServerRequestModelValidator(noteRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiNoteServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.NoteText, null as string);
		}

		[Fact]
		public async void NoteText_Create_length()
		{
			Mock<INoteRepository> noteRepository = new Mock<INoteRepository>();
			noteRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Note()));

			var validator = new ApiNoteServerRequestModelValidator(noteRepository.Object);
			await validator.ValidateCreateAsync(new ApiNoteServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.NoteText, new string('A', 8001));
		}

		[Fact]
		public async void NoteText_Update_length()
		{
			Mock<INoteRepository> noteRepository = new Mock<INoteRepository>();
			noteRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Note()));

			var validator = new ApiNoteServerRequestModelValidator(noteRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiNoteServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.NoteText, new string('A', 8001));
		}

		[Fact]
		public async void OfficerId_Create_Valid_Reference()
		{
			Mock<INoteRepository> noteRepository = new Mock<INoteRepository>();
			noteRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(new Officer()));

			var validator = new ApiNoteServerRequestModelValidator(noteRepository.Object);
			await validator.ValidateCreateAsync(new ApiNoteServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Create_Invalid_Reference()
		{
			Mock<INoteRepository> noteRepository = new Mock<INoteRepository>();
			noteRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(null));

			var validator = new ApiNoteServerRequestModelValidator(noteRepository.Object);

			await validator.ValidateCreateAsync(new ApiNoteServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Update_Valid_Reference()
		{
			Mock<INoteRepository> noteRepository = new Mock<INoteRepository>();
			noteRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(new Officer()));

			var validator = new ApiNoteServerRequestModelValidator(noteRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiNoteServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OfficerId, 1);
		}

		[Fact]
		public async void OfficerId_Update_Invalid_Reference()
		{
			Mock<INoteRepository> noteRepository = new Mock<INoteRepository>();
			noteRepository.Setup(x => x.OfficerByOfficerId(It.IsAny<int>())).Returns(Task.FromResult<Officer>(null));

			var validator = new ApiNoteServerRequestModelValidator(noteRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiNoteServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OfficerId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>be58e66b9488357a7e5424b6b63c9ee4</Hash>
</Codenesium>*/