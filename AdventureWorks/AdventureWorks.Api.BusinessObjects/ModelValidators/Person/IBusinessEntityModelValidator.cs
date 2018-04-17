using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBusinessEntityModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(BusinessEntityModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, BusinessEntityModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c7da8496197fd4c6df1a2a00b669914e</Hash>
</Codenesium>*/