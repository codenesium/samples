using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiEmployeeModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmployeeModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>76b3b3a33737f4680736dbc8b34f8033</Hash>
</Codenesium>*/