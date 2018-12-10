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

		protected IShipMethodRepository ShipMethodRepository { get; private set; }

		public AbstractApiShipMethodServerRequestModelValidator(IShipMethodRepository shipMethodRepository)
		{
			this.ShipMethodRepository = shipMethodRepository;
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => (!x?.Name.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiShipMethodServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiShipMethodServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void ShipBaseRules()
		{
		}

		public virtual void ShipRateRules()
		{
		}

		protected async Task<bool> BeUniqueByName(ApiShipMethodServerRequestModel model,  CancellationToken cancellationToken)
		{
			ShipMethod record = await this.ShipMethodRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.ShipMethodID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected async Task<bool> BeUniqueByRowguid(ApiShipMethodServerRequestModel model,  CancellationToken cancellationToken)
		{
			ShipMethod record = await this.ShipMethodRepository.ByRowguid(model.Rowguid);

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
    <Hash>b620b3ee6ab4728d2c89dc7ab2084ad1</Hash>
</Codenesium>*/