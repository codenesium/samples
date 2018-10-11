using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public class ApiChainStatusRequestModelValidator : AbstractApiChainStatusRequestModelValidator, IApiChainStatusRequestModelValidator
	{
		public ApiChainStatusRequestModelValidator(IChainStatusRepository chainStatusRepository)
			: base(chainStatusRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiChainStatusRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiChainStatusRequestModel model)
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
    <Hash>24b2d600e232953fdb163c9a33cefd7b</Hash>
</Codenesium>*/