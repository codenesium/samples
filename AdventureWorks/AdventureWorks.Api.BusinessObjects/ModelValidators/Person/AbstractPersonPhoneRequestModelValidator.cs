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
	public abstract class AbstractApiPersonPhoneRequestModelValidator: AbstractValidator<ApiPersonPhoneRequestModel>
	{
		public new ValidationResult Validate(ApiPersonPhoneRequestModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiPersonPhoneRequestModel model)
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
    <Hash>ce21456f9dd6d313db057726e070bbae</Hash>
</Codenesium>*/