using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBusinessEntityContactModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(BusinessEntityContactModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, BusinessEntityContactModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>3320c7a761ef00c7df8250a744d66095</Hash>
</Codenesium>*/