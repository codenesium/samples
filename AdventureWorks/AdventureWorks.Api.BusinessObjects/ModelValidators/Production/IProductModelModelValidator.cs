using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductModelRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModelRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>37dce11a0263902e6a497e7d7bed32e6</Hash>
</Codenesium>*/