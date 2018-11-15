using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiVersionInfoServerRequestModelValidator : AbstractApiVersionInfoServerRequestModelValidator, IApiVersionInfoServerRequestModelValidator
	{
		public ApiVersionInfoServerRequestModelValidator(IVersionInfoRepository versionInfoRepository)
			: base(versionInfoRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVersionInfoServerRequestModel model)
		{
			this.AppliedOnRules();
			this.DescriptionRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(long id, ApiVersionInfoServerRequestModel model)
		{
			this.AppliedOnRules();
			this.DescriptionRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(long id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>08224a357a2175609a3c8d3699a02e35</Hash>
</Codenesium>*/