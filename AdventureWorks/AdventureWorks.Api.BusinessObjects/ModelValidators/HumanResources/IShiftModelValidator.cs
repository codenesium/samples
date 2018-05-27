using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiShiftRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShiftRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShiftRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cc8534d1ca2373b089c7f6619b56edbf</Hash>
</Codenesium>*/