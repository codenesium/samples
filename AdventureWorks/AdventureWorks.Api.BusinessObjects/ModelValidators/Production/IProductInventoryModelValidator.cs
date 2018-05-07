using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IProductInventoryModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ProductInventoryModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ProductInventoryModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>228853265fa8e6832be563fe9421ad37</Hash>
</Codenesium>*/