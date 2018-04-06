using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractSalesTaxRateModelValidator: AbstractValidator<SalesTaxRateModel>
	{
		public new ValidationResult Validate(SalesTaxRateModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(SalesTaxRateModel model)
		{
			return await base.ValidateAsync(model);
		}

		public IStateProvinceRepository StateProvinceRepository {get; set;}
		public virtual void StateProvinceIDRules()
		{
			RuleFor(x => x.StateProvinceID).NotNull();
			RuleFor(x => x.StateProvinceID).Must(BeValidStateProvince).When(x => x ?.StateProvinceID != null).WithMessage("Invalid reference");
		}

		public virtual void TaxTypeRules()
		{
			RuleFor(x => x.TaxType).NotNull();
		}

		public virtual void TaxRateRules()
		{
			RuleFor(x => x.TaxRate).NotNull();
		}

		public virtual void NameRules()
		{
			RuleFor(x => x.Name).NotNull();
			RuleFor(x => x.Name).Length(0,50);
		}

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}

		public bool BeValidStateProvince(int id)
		{
			Response response = new Response();

			this.StateProvinceRepository.GetById(id,response);
			return response.StateProvinces.Count > 0;
		}
	}
}

/*<Codenesium>
    <Hash>77a139d6cdde87a96a4146c4a9b07e92</Hash>
</Codenesium>*/