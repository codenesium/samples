using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public class PaymentTypeModelValidator: AbstractPaymentTypeModelValidator, IPaymentTypeModelValidator
	{
		public PaymentTypeModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(PaymentTypeModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PaymentTypeModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>8aace15574c5c3ea65a7132ec06a5e87</Hash>
</Codenesium>*/