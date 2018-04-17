using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IDepartmentModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(DepartmentModel model);
		Task<ValidationResult>  ValidateUpdateAsync(short id, DepartmentModel model);
		Task<ValidationResult>  ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>348fbc193f3f264ff989473a92c4e58b</Hash>
</Codenesium>*/