using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiStateProvinceModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStateProvinceModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStateProvinceModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>43fb7eecf034bbc879a1d6da85102e06</Hash>
</Codenesium>*/