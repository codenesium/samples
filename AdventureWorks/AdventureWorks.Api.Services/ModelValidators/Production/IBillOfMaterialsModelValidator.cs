using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiBillOfMaterialsRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBillOfMaterialsRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBillOfMaterialsRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0b10d36bdbd4fc51c52bf2d9e91a2d38</Hash>
</Codenesium>*/