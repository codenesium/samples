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
	public abstract class AbstractApiAddressRequestModelValidator: AbstractValidator<ApiAddressRequestModel>
	{
		public new ValidationResult Validate(ApiAddressRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiAddressRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IAddressRepository AddressRepository { get; set; }
		public virtual void AddressLine1Rules()
		{
			this.RuleFor(x => x.AddressLine1).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetAddressLine1AddressLine2CityStateProvinceIDPostalCode).When(x => x ?.AddressLine1 != null).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressRequestModel.AddressLine1));
			this.RuleFor(x => x.AddressLine1).Length(0, 60);
		}

		public virtual void AddressLine2Rules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetAddressLine1AddressLine2CityStateProvinceIDPostalCode).When(x => x ?.AddressLine2 != null).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressRequestModel.AddressLine2));
			this.RuleFor(x => x.AddressLine2).Length(0, 60);
		}

		public virtual void CityRules()
		{
			this.RuleFor(x => x.City).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetAddressLine1AddressLine2CityStateProvinceIDPostalCode).When(x => x ?.City != null).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressRequestModel.City));
			this.RuleFor(x => x.City).Length(0, 30);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void PostalCodeRules()
		{
			this.RuleFor(x => x.PostalCode).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetAddressLine1AddressLine2CityStateProvinceIDPostalCode).When(x => x ?.PostalCode != null).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressRequestModel.PostalCode));
			this.RuleFor(x => x.PostalCode).Length(0, 15);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void StateProvinceIDRules()
		{
			this.RuleFor(x => x.StateProvinceID).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueGetAddressLine1AddressLine2CityStateProvinceIDPostalCode).When(x => x ?.StateProvinceID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressRequestModel.StateProvinceID));
		}

		private async Task<bool> BeUniqueGetAddressLine1AddressLine2CityStateProvinceIDPostalCode(ApiAddressRequestModel model,  CancellationToken cancellationToken)
		{
			var record = await this.AddressRepository.GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(model.AddressLine1,model.AddressLine2,model.City,model.StateProvinceID,model.PostalCode);

			return record == null;
		}
	}
}

/*<Codenesium>
    <Hash>c81281f1722cbe410268b380b4c11b06</Hash>
</Codenesium>*/