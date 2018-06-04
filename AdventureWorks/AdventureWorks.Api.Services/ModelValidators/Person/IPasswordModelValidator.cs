using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiPasswordRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPasswordRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPasswordRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>641183a5c08c76b037a90d740bcad72d</Hash>
</Codenesium>*/