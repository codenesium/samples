using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiColumnSameAsFKTableRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiColumnSameAsFKTableRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiColumnSameAsFKTableRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3589a89d921b73476531f4ad0c3c8141</Hash>
</Codenesium>*/