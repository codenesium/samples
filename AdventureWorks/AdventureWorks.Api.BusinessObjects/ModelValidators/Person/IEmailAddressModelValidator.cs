using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiEmailAddressRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmailAddressRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmailAddressRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b87d4f69885e9359b4fe86d3bcca9260</Hash>
</Codenesium>*/