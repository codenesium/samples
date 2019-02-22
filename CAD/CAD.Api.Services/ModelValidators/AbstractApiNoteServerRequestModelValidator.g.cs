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
	public abstract class AbstractApiNoteServerRequestModelValidator : AbstractValidator<ApiNoteServerRequestModel>
	{
		private int existingRecordId;

		protected INoteRepository NoteRepository { get; private set; }

		public AbstractApiNoteServerRequestModelValidator(INoteRepository noteRepository)
		{
			this.NoteRepository = noteRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiNoteServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
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
    <Hash>f7d569ffae5200e24646ac97f4fb4358</Hash>
</Codenesium>*/