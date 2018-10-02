using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiVProductAndDescriptionRequestModelValidator : AbstractApiVProductAndDescriptionRequestModelValidator, IApiVProductAndDescriptionRequestModelValidator
	{
		public ApiVProductAndDescriptionRequestModelValidator(IVProductAndDescriptionRepository vProductAndDescriptionRepository)
			: base(vProductAndDescriptionRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVProductAndDescriptionRequestModel model)
		{
			this.DescriptionRules();
			this.NameRules();
			this.ProductIDRules();
			this.ProductModelRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiVProductAndDescriptionRequestModel model)
		{
			this.DescriptionRules();
			this.NameRules();
			this.ProductIDRules();
			this.ProductModelRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(string id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>ec5edd3c64a47b24602807fb4805c8fc</Hash>
</Codenesium>*/