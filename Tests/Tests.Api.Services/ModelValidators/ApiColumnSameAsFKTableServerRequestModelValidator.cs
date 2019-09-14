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
	public class ApiColumnSameAsFKTableServerRequestModelValidator : AbstractValidator<ApiColumnSameAsFKTableServerRequestModel>, IApiColumnSameAsFKTableServerRequestModelValidator
	{
		private int existingRecordId;

		protected IColumnSameAsFKTableRepository ColumnSameAsFKTableRepository { get; private set; }

		public ApiColumnSameAsFKTableServerRequestModelValidator(IColumnSameAsFKTableRepository columnSameAsFKTableRepository)
		{
			this.ColumnSameAsFKTableRepository = columnSameAsFKTableRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiColumnSameAsFKTableServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiColumnSameAsFKTableServerRequestModel model)
		{
			this.PersonRules();
			this.PersonIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiColumnSameAsFKTableServerRequestModel model)
		{
			this.PersonRules();
			this.PersonIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>29012060d03cd5415a0929dd6f236078</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/