using AdventureWorksNS.Api.Contracts;
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

		protected IPersonRepository PersonRepository { get; private set; }

		public AbstractApiPersonServerRequestModelValidator(IPersonRepository personRepository)
		{
			this.PersonRepository = personRepository;
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
			this.RuleFor(x => x.FirstName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FirstName).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.LastName).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void MiddleNameRules()
		{
			this.RuleFor(x => x.MiddleName).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameStyleRules()
		{
		}

		public virtual void PersonTypeRules()
		{
			this.RuleFor(x => x.PersonType).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.PersonType).Length(0, 2).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiPersonServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void SuffixRules()
		{
			this.RuleFor(x => x.Suffix).Length(0, 10).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void TitleRules()
		{
			this.RuleFor(x => x.Title).Length(0, 8).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeUniqueByRowguid(ApiPersonServerRequestModel model,  CancellationToken cancellationToken)
		{
			Person record = await this.PersonRepository.ByRowguid(model.Rowguid);

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
    <Hash>4e63d382ebe1cdf31baf8add993e8125</Hash>
</Codenesium>*/