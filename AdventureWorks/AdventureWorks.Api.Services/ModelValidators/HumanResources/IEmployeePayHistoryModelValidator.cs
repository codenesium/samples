using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiEmployeePayHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmployeePayHistoryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeePayHistoryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ac69b2464df3aeae6cf2a5f366372d57</Hash>
</Codenesium>*/