using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public class ApiPaymentTypeServerRequestModelValidator : AbstractApiPaymentTypeServerRequestModelValidator, IApiPaymentTypeServerRequestModelValidator
	{
		public ApiPaymentTypeServerRequestModelValidator(IPaymentTypeRepository paymentTypeRepository)
			: base(paymentTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPaymentTypeServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPaymentTypeServerRequestModel model)
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
    <Hash>ec2ae95be4305010a6f636cabe4c076d</Hash>
</Codenesium>*/