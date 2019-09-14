using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiNoteServerRequestModelValidator : AbstractValidator<ApiNoteServerRequestModel>, IApiNoteServerRequestModelValidator
	{
		private int existingRecordId;

		protected INoteRepository NoteRepository { get; private set; }

		public ApiNoteServerRequestModelValidator(INoteRepository noteRepository)
		{
			this.NoteRepository = noteRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiNoteServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
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

		public virtual void CallIdRules()
		{
			this.RuleFor(x => x.CallId).MustAsync(this.BeValidCallByCallId).When(x => !x?.CallId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void DateCreatedRules()
		{
		}

		public virtual void NoteTextRules()
		{
			this.RuleFor(x => x.NoteText).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.NoteText).Length(0, 8000).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void OfficerIdRules()
		{
			this.RuleFor(x => x.OfficerId).MustAsync(this.BeValidOfficerByOfficerId).When(x => !x?.OfficerId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidCallByCallId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.NoteRepository.CallByCallId(id);

			return record != null;
		}

		protected async Task<bool> BeValidOfficerByOfficerId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.NoteRepository.OfficerByOfficerId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>61d19818a101d266fb163f15e91ee013</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/