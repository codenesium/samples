using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Services
{
	public partial interface IApiColumnSameAsFKTableServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiColumnSameAsFKTableServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiColumnSameAsFKTableServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>08f7c53f492cc81e955b1e7d7f514925</Hash>
</Codenesium>*/