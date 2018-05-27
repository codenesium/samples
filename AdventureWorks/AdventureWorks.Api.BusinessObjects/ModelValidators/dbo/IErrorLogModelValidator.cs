using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiErrorLogRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiErrorLogRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiErrorLogRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fa9f52151e7f0c9001141c283b15013a</Hash>
</Codenesium>*/