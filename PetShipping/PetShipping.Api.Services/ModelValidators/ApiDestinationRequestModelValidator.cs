using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiDestinationRequestModelValidator : AbstractApiDestinationRequestModelValidator, IApiDestinationRequestModelValidator
	{
		public ApiDestinationRequestModelValidator(IDestinationRepository destinationRepository)
			: base(destinationRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDestinationRequestModel model)
		{
			this.CountryIdRules();
			this.NameRules();
			this.OrderRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDestinationRequestModel model)
		{
			this.CountryIdRules();
			this.NameRules();
			this.OrderRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>419eba262a28283f78bb8b60992d4650</Hash>
</Codenesium>*/