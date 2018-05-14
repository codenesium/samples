using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiEmailAddressModelValidator: AbstractValidator<ApiEmailAddressModel>
	{
		public new ValidationResult Validate(ApiEmailAddressModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmailAddressModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void EmailAddress1Rules()
		{
			this.RuleFor(x => x.EmailAddress1).Length(0, 50);
		}

		public virtual void EmailAddressIDRules()
		{
			this.RuleFor(x => x.EmailAddressID).NotNull();
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x.Rowguid).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>1fac812e8d132b5c54ed283a7601caf7</Hash>
</Codenesium>*/