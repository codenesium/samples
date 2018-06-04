using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services

{
	public abstract class AbstractApiEmployeeRequestModelValidator: AbstractValidator<ApiEmployeeRequestModel>
	{
		private int existingRecordId;

		public new ValidationResult Validate(ApiEmployeeRequestModel model, int id)
		{
			this.existingRecordId = id;
			return base.Validate(model);
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmployeeRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await base.ValidateAsync(model);
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).NotNull();
			this.RuleFor(x => x.FirstName).Length(0, 128);
		}

		public virtual void IsSalesPersonRules()
		{
			this.RuleFor(x => x.IsSalesPerson).NotNull();
		}

		public virtual void IsShipperRules()
		{
			this.RuleFor(x => x.IsShipper).NotNull();
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).NotNull();
			this.RuleFor(x => x.LastName).Length(0, 128);
		}
	}
}

/*<Codenesium>
    <Hash>0dfc16a3e89246e8eb18d19c7aae0987</Hash>
</Codenesium>*/