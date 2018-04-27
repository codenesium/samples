using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class HandlerModelValidator: AbstractHandlerModelValidator, IHandlerModelValidator
	{
		public HandlerModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(HandlerModel model)
		{
			this.CountryIdRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, HandlerModel model)
		{
			this.CountryIdRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>aa54da6764dd33c0f2538b2ccfc9c61d</Hash>
</Codenesium>*/