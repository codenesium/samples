using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiStoreRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStoreRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStoreRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4f9c5f2a30b977be62ddb43092474307</Hash>
</Codenesium>*/