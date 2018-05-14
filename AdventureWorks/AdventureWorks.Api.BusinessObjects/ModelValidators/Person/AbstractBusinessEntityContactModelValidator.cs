using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiBusinessEntityContactModelValidator: AbstractValidator<ApiBusinessEntityContactModel>
	{
		public new ValidationResult Validate(ApiBusinessEntityContactModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiBusinessEntityContactModel model)
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
    <Hash>bf08223144d4653769239432251fd419</Hash>
</Codenesium>*/