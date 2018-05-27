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
	public abstract class AbstractApiEmailAddressRequestModelValidator: AbstractValidator<ApiEmailAddressRequestModel>
	{
		public new ValidationResult Validate(ApiEmailAddressRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmailAddressRequestModel model)
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
    <Hash>f8dad1d4ad89ba8290f54a3abca54132</Hash>
</Codenesium>*/