using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiEmployeeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmployeeRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>771c29b0e6b13d1858a7752768b4569c</Hash>
</Codenesium>*/