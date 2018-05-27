using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiPhoneNumberTypeRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPhoneNumberTypeRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPhoneNumberTypeRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>be0b712d128bdc3d9214f02b74820d5d</Hash>
</Codenesium>*/