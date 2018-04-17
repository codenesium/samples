using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractAddressModelValidator: AbstractValidator<AddressModel>
	{
		public new ValidationResult Validate(AddressModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(AddressModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IStateProvinceRepository StateProvinceRepository { get; set; }
		public virtual void AddressLine1Rules()
		{
			this.RuleFor(x => x.AddressLine1).NotNull();
			this.RuleFor(x => x.AddressLine1).Length(0, 60);
		}

		public virtual void AddressLine2Rules()
		{
			this.RuleFor(x => x.AddressLine2).Length(0, 60);
		}

		public virtual void CityRules()
		{
			this.RuleFor(x => x.City).NotNull();
			this.RuleFor(x => x.City).Length(0, 30);
		}

		public virtual void StateProvinceIDRules()
		{
			this.RuleFor(x => x.StateProvinceID).NotNull();
			this.RuleFor(x => x.StateProvinceID).Must(this.BeValidStateProvince).When(x => x ?.StateProvinceID != null).WithMessage("Invalid reference");
		}

		public virtual void PostalCodeRules()
		{
			this.RuleFor(x => x.PostalCode).NotNull();
			this.RuleFor(x => x.PostalCode).Length(0, 15);
		}

		public virtual void SpatialLocationRules()
		{                       }

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		private bool BeValidStateProvince(int id)
		{
			return this.StateProvinceRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>f24418d560b010ab787b064d6050b6e7</Hash>
</Codenesium>*/