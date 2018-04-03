using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service

{
	public abstract class AbstractCustomerModelValidator: AbstractValidator<CustomerModel>
	{
		public new ValidationResult Validate(CustomerModel model)
		{
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(CustomerModel model)
		{
			return await base.ValidateAsync(model);
		}

		public virtual void PersonIDRules()
		{                       }

		public virtual void StoreIDRules()
		{                       }

		public virtual void TerritoryIDRules()
		{                       }

		public virtual void AccountNumberRules()
		{
			RuleFor(x => x.AccountNumber).NotNull();
			RuleFor(x => x.AccountNumber).Length(0,10);
		}

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
    <Hash>e108fedd3e8abad4adeb4cbdc8b9a014</Hash>
</Codenesium>*/