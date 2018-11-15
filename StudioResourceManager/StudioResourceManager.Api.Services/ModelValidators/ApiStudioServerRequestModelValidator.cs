using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiStudioServerRequestModelValidator : AbstractApiStudioServerRequestModelValidator, IApiStudioServerRequestModelValidator
	{
		public ApiStudioServerRequestModelValidator(IStudioRepository studioRepository)
			: base(studioRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiStudioServerRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.NameRules();
			this.ProvinceRules();
			this.WebsiteRules();
			this.ZipRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudioServerRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.NameRules();
			this.ProvinceRules();
			this.WebsiteRules();
			this.ZipRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>513ecf83bf68e82f6c20c40909035d46</Hash>
</Codenesium>*/