using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface ISaleModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SaleModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SaleModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4f3a7b221931541885081140efae9d9e</Hash>
</Codenesium>*/