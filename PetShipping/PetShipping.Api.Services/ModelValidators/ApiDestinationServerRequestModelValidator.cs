using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiDestinationServerRequestModelValidator : AbstractApiDestinationServerRequestModelValidator, IApiDestinationServerRequestModelValidator
	{
		public ApiDestinationServerRequestModelValidator(IDestinationRepository destinationRepository)
			: base(destinationRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiDestinationServerRequestModel model)
		{
			this.CountryIdRules();
			this.NameRules();
			this.OrderRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDestinationServerRequestModel model)
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
    <Hash>6afc81da07e824a8d5170c0a13eca4e3</Hash>
</Codenesium>*/