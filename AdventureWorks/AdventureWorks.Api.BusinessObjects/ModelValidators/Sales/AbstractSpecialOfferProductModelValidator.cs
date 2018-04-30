using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractSpecialOfferProductModelValidator: AbstractValidator<SpecialOfferProductModel>
	{
		public new ValidationResult Validate(SpecialOfferProductModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(SpecialOfferProductModel model)
		{
			return await base.ValidateAsync(model);
		}

		public ISpecialOfferRepository SpecialOfferRepository { get; set; }
		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void ProductIDRules()
		{
			this.RuleFor(x => x.ProductID).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}

		private bool BeValidSpecialOffer(int id)
		{
			return this.SpecialOfferRepository.GetByIdDirect(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>065754bd26b5ba0b29b75ee7841ab5de</Hash>
</Codenesium>*/