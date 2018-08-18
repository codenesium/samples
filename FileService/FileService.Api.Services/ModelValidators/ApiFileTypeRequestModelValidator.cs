using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public class ApiFileTypeRequestModelValidator : AbstractApiFileTypeRequestModelValidator, IApiFileTypeRequestModelValidator
	{
		public ApiFileTypeRequestModelValidator(IFileTypeRepository fileTypeRepository)
			: base(fileTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiFileTypeRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileTypeRequestModel model)
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
    <Hash>722a92c620596aa4aa0522986299b87e</Hash>
</Codenesium>*/