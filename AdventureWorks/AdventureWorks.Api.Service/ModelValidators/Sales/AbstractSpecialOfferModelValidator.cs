using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractSpecialOfferModelValidator: AbstractValidator<SpecialOfferModel>
	{
		public new ValidationResult Validate(SpecialOfferModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(SpecialOfferModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void DescriptionRules()
		{
			RuleFor(x => x.Description).NotNull();
			RuleFor(x => x.Description).Length(0,255);
		}

		public virtual void DiscountPctRules()
		{
			RuleFor(x => x.DiscountPct).NotNull();
		}

		public virtual void TypeRules()
		{
			RuleFor(x => x.Type).NotNull();
			RuleFor(x => x.Type).Length(0,50);
		}

		public virtual void CategoryRules()
		{
			RuleFor(x => x.Category).NotNull();
			RuleFor(x => x.Category).Length(0,50);
		}

		public virtual void StartDateRules()
		{
			RuleFor(x => x.StartDate).NotNull();
		}

		public virtual void EndDateRules()
		{
			RuleFor(x => x.EndDate).NotNull();
		}

		public virtual void MinQtyRules()
		{
			RuleFor(x => x.MinQty).NotNull();
		}

		public virtual void MaxQtyRules()
		{                       }

		public virtual void RowguidRules()
		{
			RuleFor(x => x.Rowguid).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			RuleFor(x => x.ModifiedDate).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>273b840f601a7f37b08ad35bbc500e34</Hash>
</Codenesium>*/