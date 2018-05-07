using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBusinessEntityContactModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(BusinessEntityContactModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, BusinessEntityContactModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>9a65352ef406cf1e34a9262af160fc4b</Hash>
</Codenesium>*/