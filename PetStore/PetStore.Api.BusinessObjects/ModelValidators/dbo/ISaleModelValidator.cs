using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface ISaleModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SaleModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SaleModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>38eed0ee578f3020935a9e9c39eaa7b6</Hash>
</Codenesium>*/