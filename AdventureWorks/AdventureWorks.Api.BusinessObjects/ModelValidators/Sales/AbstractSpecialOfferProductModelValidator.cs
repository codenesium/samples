using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiSpecialOfferProductModelValidator: AbstractValidator<ApiSpecialOfferProductModel>
	{
		public new ValidationResult Validate(ApiSpecialOfferProductModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiSpecialOfferProductModel model)
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
			return this.SpecialOfferRepository.Get(id) != null;
		}
	}
}

/*<Codenesium>
    <Hash>60e830e2c0652f300a5928322b314a11</Hash>
</Codenesium>*/