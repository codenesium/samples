using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public class ApiPaymentTypeRequestModelValidator : AbstractApiPaymentTypeRequestModelValidator, IApiPaymentTypeRequestModelValidator
	{
		public ApiPaymentTypeRequestModelValidator(IPaymentTypeRepository paymentTypeRepository)
			: base(paymentTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPaymentTypeRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPaymentTypeRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>4720aca79a0c6b11dee2499bfcec03b6</Hash>
</Codenesium>*/