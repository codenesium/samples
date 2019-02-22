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
	public abstract class AbstractApiCallPersonServerRequestModelValidator : AbstractValidator<ApiCallPersonServerRequestModel>
	{
		private int existingRecordId;

		protected ICallPersonRepository CallPersonRepository { get; private set; }

		public AbstractApiCallPersonServerRequestModelValidator(ICallPersonRepository callPersonRepository)
		{
			this.CallPersonRepository = callPersonRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCallPersonServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).Length(0, 8000).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PersonIdRules()
		{
			this.RuleFor(x => x.PersonId).MustAsync(this.BeValidPersonByPersonId).When(x => !x?.PersonId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void PersonTypeIdRules()
		{
			this.RuleFor(x => x.PersonTypeId).MustAsync(this.BeValidPersonTypeByPersonTypeId).When(x => !x?.PersonTypeId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidPersonByPersonId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.CallPersonRepository.PersonByPersonId(id);

			return record != null;
		}

		protected async Task<bool> BeValidPersonTypeByPersonTypeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.CallPersonRepository.PersonTypeByPersonTypeId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>f5b5c315c994f33b5f4f18eda7136e36</Hash>
</Codenesium>*/