using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBusinessEntityModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(BusinessEntityModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, BusinessEntityModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>336e936cbc8218c3f735efc04c09ea2b</Hash>
</Codenesium>*/