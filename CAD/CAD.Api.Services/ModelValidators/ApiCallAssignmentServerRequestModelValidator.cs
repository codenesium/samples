using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiCallAssignmentServerRequestModelValidator : AbstractApiCallAssignmentServerRequestModelValidator, IApiCallAssignmentServerRequestModelValidator
	{
		public ApiCallAssignmentServerRequestModelValidator(ICallAssignmentRepository callAssignmentRepository)
			: base(callAssignmentRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCallAssignmentServerRequestModel model)
		{
			this.CallIdRules();
			this.UnitIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCallAssignmentServerRequestModel model)
		{
			this.CallIdRules();
			this.UnitIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>e1fbc7ba979d90f905071a49a2a17ef8</Hash>
</Codenesium>*/