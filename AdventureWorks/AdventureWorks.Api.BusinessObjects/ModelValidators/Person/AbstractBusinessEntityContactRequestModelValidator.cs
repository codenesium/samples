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
	public abstract class AbstractApiBusinessEntityContactRequestModelValidator: AbstractValidator<ApiBusinessEntityContactRequestModel>
	{
		public new ValidationResult Validate(ApiBusinessEntityContactRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiBusinessEntityContactRequestModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ContactTypeIDRules()
		{
			this.RuleFor(x => x.ContactTypeID).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void PersonIDRules()
		{
			this.RuleFor(x => x.PersonID).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>db84f59d7931399d20c1fd9f38c37c2b</Hash>
</Codenesium>*/