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

		protected IUnitMeasureRepository UnitMeasureRepository { get; private set; }

		public AbstractApiUnitMeasureServerRequestModelValidator(IUnitMeasureRepository unitMeasureRepository)
		{
			this.UnitMeasureRepository = unitMeasureRepository;
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => (!x?.Name.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiUnitMeasureServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeUniqueByName(ApiUnitMeasureServerRequestModel model,  CancellationToken cancellationToken)
		{
			UnitMeasure record = await this.UnitMeasureRepository.ByName(model.Name);

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
    <Hash>3b5b573666e7bf8d78c8e8c5a72ccff0</Hash>
</Codenesium>*/