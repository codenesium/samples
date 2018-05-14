using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects

{
	public abstract class AbstractApiPersonPhoneModelValidator: AbstractValidator<ApiPersonPhoneModel>
	{
		public new ValidationResult Validate(ApiPersonPhoneModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPersonPhoneModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
			this.RuleFor(x => x.ModifiedDate).NotNull();
		}

		public virtual void PhoneNumberRules()
		{
			this.RuleFor(x => x.PhoneNumber).NotNull();
			this.RuleFor(x => x.PhoneNumber).Length(0, 25);
		}

		public virtual void PhoneNumberTypeIDRules()
		{
			this.RuleFor(x => x.PhoneNumberTypeID).NotNull();
		}
	}
}

/*<Codenesium>
    <Hash>a8ac1a0307e5519e7b59e0d4abda5d21</Hash>
</Codenesium>*/