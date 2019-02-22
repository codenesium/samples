using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiNoteServerRequestModelValidator : AbstractApiNoteServerRequestModelValidator, IApiNoteServerRequestModelValidator
	{
		public ApiNoteServerRequestModelValidator(INoteRepository noteRepository)
			: base(noteRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiNoteServerRequestModel model)
		{
			this.CallIdRules();
			this.DateCreatedRules();
			this.NoteTextRules();
			this.OfficerIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiNoteServerRequestModel model)
		{
			this.CallIdRules();
			this.DateCreatedRules();
			this.NoteTextRules();
			this.OfficerIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>d63d86508f46858b3d8a3ffb6240450f</Hash>
</Codenesium>*/