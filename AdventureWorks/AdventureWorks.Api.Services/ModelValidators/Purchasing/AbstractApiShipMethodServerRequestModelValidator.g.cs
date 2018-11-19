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
	public abstract class AbstractApiShipMethodServerRequestModelValidator : AbstractValidator<ApiShipMethodServerRequestModel>
	{
		private int existingRecordId;

		private IShipMethodRepository shipMethodRepository;

		public AbstractApiShipMethodServerRequestModelValidator(IShipMethodRepository shipMethodRepository)
		{
			this.shipMethodRepository = shipMethodRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiShipMethodServerRequestModel model, int id)
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiShipMethodServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => !x?.Rowguid.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiShipMethodServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void ShipBaseRules()
		{
		}

		public virtual void ShipRateRules()
		{
		}

		private async Task<bool> BeUniqueByName(ApiShipMethodServerRequestModel model,  CancellationToken cancellationToken)
		{
			ShipMethod record = await this.shipMethodRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.ShipMethodID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private async Task<bool> BeUniqueByRowguid(ApiShipMethodServerRequestModel model,  CancellationToken cancellationToken)
		{
			ShipMethod record = await this.shipMethodRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.ShipMethodID == this.existingRecordId))
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
    <Hash>1f38cab975484a2f5ba48195ea9ff09d</Hash>
</Codenesium>*/