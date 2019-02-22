using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiUnitServerRequestModelValidator : AbstractApiUnitServerRequestModelValidator, IApiUnitServerRequestModelValidator
	{
		public ApiUnitServerRequestModelValidator(IUnitRepository unitRepository)
			: base(unitRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiUnitServerRequestModel model)
		{
			this.CallSignRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiUnitServerRequestModel model)
		{
			this.CallSignRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>38cffe6b671abce2bd0d47a6aa17b6ed</Hash>
</Codenesium>*/