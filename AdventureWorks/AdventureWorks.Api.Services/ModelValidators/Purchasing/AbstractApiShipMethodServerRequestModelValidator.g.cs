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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiShipMethodServerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => !x?.Rowguid.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiShipMethodServerRequestModel.Rowguid));
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
    <Hash>7f03f88837a4054e2a932928b5812a09</Hash>
</Codenesium>*/