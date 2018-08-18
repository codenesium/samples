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
    <Hash>4585925fb2d29ba60bcfecb6705bff0a</Hash>
</Codenesium>*/