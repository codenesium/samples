using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiStudioRequestModelValidator : AbstractApiStudioRequestModelValidator, IApiStudioRequestModelValidator
	{
		public ApiStudioRequestModelValidator(IStudioRepository studioRepository)
			: base(studioRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiStudioRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.NameRules();
			this.ProvinceRules();
			this.WebsiteRules();
			this.ZipRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudioRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.NameRules();
			this.ProvinceRules();
			this.WebsiteRules();
			this.ZipRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>a851a5ee9ed8b59ddea00663a8494dfa</Hash>
</Codenesium>*/