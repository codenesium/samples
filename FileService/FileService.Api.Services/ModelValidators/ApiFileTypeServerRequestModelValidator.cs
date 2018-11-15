using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public class ApiFileTypeServerRequestModelValidator : AbstractApiFileTypeServerRequestModelValidator, IApiFileTypeServerRequestModelValidator
	{
		public ApiFileTypeServerRequestModelValidator(IFileTypeRepository fileTypeRepository)
			: base(fileTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiFileTypeServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileTypeServerRequestModel model)
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
    <Hash>712432ce57e1a86ecee830681d4a501f</Hash>
</Codenesium>*/