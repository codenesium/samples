using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiPersonServerRequestModelValidator : AbstractValidator<ApiPersonServerRequestModel>
	{
		private int existingRecordId;

		private IPersonRepository personRepository;

		public AbstractApiPersonServerRequestModelValidator(IPersonRepository personRepository)
		{
			this.personRepository = personRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPersonServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AdditionalContactInfoRules()
		{
		}

		public virtual void DemographicRules()
		{
		}

		public virtual void EmailPromotionRules()
		{
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).NotNull();
			this.RuleFor(x => x.FirstName).Length(0, 50);
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).NotNull();
			this.RuleFor(x => x.LastName).Length(0, 50);
		}

		public virtual void MiddleNameRules()
		{
			this.RuleFor(x => x.MiddleName).Length(0, 50);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameStyleRules()
		{
		}

		public virtual void PersonTypeRules()
		{
			this.RuleFor(x => x.PersonType).NotNull();
			this.RuleFor(x => x.PersonType).Length(0, 2);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => !x?.Rowguid.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiPersonServerRequestModel.Rowguid));
		}

		public virtual void SuffixRules()
		{
			this.RuleFor(x => x.Suffix).Length(0, 10);
		}

		public virtual void TitleRules()
		{
			this.RuleFor(x => x.Title).Length(0, 8);
		}

		private async Task<bool> BeUniqueByRowguid(ApiPersonServerRequestModel model,  CancellationToken cancellationToken)
		{
			Person record = await this.personRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.BusinessEntityID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>ccecb0a875f26cb3f0bdcf50846fa91d</Hash>
</Codenesium>*/