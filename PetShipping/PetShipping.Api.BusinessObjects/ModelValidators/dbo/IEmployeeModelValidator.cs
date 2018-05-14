using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiEmployeeModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmployeeModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f2282385f50dd3737536718215322aa0</Hash>
</Codenesium>*/