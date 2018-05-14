using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiPhoneNumberTypeModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPhoneNumberTypeModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPhoneNumberTypeModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b6185a198b666f3e994a92443d4b3db0</Hash>
</Codenesium>*/