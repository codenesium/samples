using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services

{
	public abstract class AbstractApiBusinessEntityAddressRequestModelValidator: AbstractValidator<ApiBusinessEntityAddressRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiBusinessEntityAddressRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiBusinessEntityAddressRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public virtual void AddressIDRules()
		{
			this.RuleFor(x => x.AddressID).NotNull();
		}

		public virtual void AddressTypeIDRules()
		{
			this.RuleFor(x => x.AddressTypeID).NotNull();
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
    <Hash>11621f3654483226ad1af0d80cb9dc1d</Hash>
</Codenesium>*/