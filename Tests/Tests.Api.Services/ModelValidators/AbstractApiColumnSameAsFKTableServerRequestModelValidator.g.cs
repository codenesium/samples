using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiColumnSameAsFKTableServerRequestModelValidator : AbstractValidator<ApiColumnSameAsFKTableServerRequestModel>
	{
		private int existingRecordId;

		protected IColumnSameAsFKTableRepository ColumnSameAsFKTableRepository { get; private set; }

		public AbstractApiColumnSameAsFKTableServerRequestModelValidator(IColumnSameAsFKTableRepository columnSameAsFKTableRepository)
		{
			this.ColumnSameAsFKTableRepository = columnSameAsFKTableRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiColumnSameAsFKTableServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void PersonRules()
		{
			this.RuleFor(x => x.Person).MustAsync(this.BeValidPersonByPerson).When(x => !x?.Person.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void PersonIdRules()
		{
			this.RuleFor(x => x.PersonId).MustAsync(this.BeValidPersonByPersonId).When(x => !x?.PersonId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidPersonByPerson(int id,  CancellationToken cancellationToken)
		{
			var record = await this.ColumnSameAsFKTableRepository.PersonByPerson(id);

			return record != null;
		}

		protected async Task<bool> BeValidPersonByPersonId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.ColumnSameAsFKTableRepository.PersonByPersonId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>96ddc14724d777ba5a22ad138f2bcdde</Hash>
</Codenesium>*/