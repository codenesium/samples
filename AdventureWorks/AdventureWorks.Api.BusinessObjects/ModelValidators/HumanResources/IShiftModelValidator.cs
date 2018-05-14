using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiShiftModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShiftModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShiftModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a937cff82916fb9b84ad6995db6c9bae</Hash>
</Codenesium>*/