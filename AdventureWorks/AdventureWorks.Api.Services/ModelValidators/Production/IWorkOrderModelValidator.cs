using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiWorkOrderRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiWorkOrderRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiWorkOrderRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f97aec0599f1c5be47c0ba7fd841364d</Hash>
</Codenesium>*/