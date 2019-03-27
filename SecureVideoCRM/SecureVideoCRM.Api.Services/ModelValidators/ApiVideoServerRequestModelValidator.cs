using FluentValidation.Results;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public class ApiVideoServerRequestModelValidator : AbstractApiVideoServerRequestModelValidator, IApiVideoServerRequestModelValidator
	{
		public ApiVideoServerRequestModelValidator(IVideoRepository videoRepository)
			: base(videoRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiVideoServerRequestModel model)
		{
			this.DescriptionRules();
			this.TitleRules();
			this.UrlRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiVideoServerRequestModel model)
		{
			this.DescriptionRules();
			this.TitleRules();
			this.UrlRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>5abf7fc310ba817c900cf80841313bf4</Hash>
</Codenesium>*/