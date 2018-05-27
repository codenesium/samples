using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiStateProvinceRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStateProvinceRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateProvinceRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3e044766a1855549c0139365c7dceee4</Hash>
</Codenesium>*/