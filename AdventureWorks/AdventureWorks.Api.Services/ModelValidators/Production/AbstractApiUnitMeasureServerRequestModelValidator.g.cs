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
	public abstract class AbstractApiUnitMeasureServerRequestModelValidator : AbstractValidator<ApiUnitMeasureServerRequestModel>
	{
		private string existingRecordId;

		private IUnitMeasureRepository unitMeasureRepository;

		public AbstractApiUnitMeasureServerRequestModelValidator(IUnitMeasureRepository unitMeasureRepository)
		{
			this.unitMeasureRepository = unitMeasureRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiUnitMeasureServerRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiUnitMeasureServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		private async Task<bool> BeUniqueByName(ApiUnitMeasureServerRequestModel model,  CancellationToken cancellationToken)
		{
			UnitMeasure record = await this.unitMeasureRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(string) && record.UnitMeasureCode == this.existingRecordId))
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
    <Hash>e409749474c409d4498dcf074e5ad92a</Hash>
</Codenesium>*/