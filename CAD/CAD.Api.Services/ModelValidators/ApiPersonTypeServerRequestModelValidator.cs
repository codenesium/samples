using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiPersonTypeServerRequestModelValidator : AbstractApiPersonTypeServerRequestModelValidator, IApiPersonTypeServerRequestModelValidator
	{
		public ApiPersonTypeServerRequestModelValidator(IPersonTypeRepository personTypeRepository)
			: base(personTypeRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPersonTypeServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonTypeServerRequestModel model)
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
    <Hash>35117fe9c3c156ba6cf214deea5e553c</Hash>
</Codenesium>*/