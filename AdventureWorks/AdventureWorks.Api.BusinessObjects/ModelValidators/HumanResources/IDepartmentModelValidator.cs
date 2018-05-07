using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IDepartmentModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(DepartmentModel model);
		Task<ValidationResult> ValidateUpdateAsync(short id, DepartmentModel model);
		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>26f095adc67d027d7d80da5088e85ba7</Hash>
</Codenesium>*/