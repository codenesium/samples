using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiShipMethodRequestModelValidator: AbstractValidator<ApiShipMethodRequestModel>
	{
		public new ValidationResult Validate(ApiShipMethodRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiShipMethodRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IShipMethodRepository ShipMethodRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiShipMethodRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ShipBaseRules()
		{
			this.RuleFor(x => x.ShipBase).NotNull();
		}

		public virtual void ShipRateRules()
		{
			this.RuleFor(x => x.ShipRate).NotNull();
		}

		private async Task<bool> BeUniqueGetName(ApiShipMethodRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.ShipMethodRepository.GetName(model.Name);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>5ab2d2d5fd6f0bd608746b0a27e51806</Hash>
</Codenesium>*/