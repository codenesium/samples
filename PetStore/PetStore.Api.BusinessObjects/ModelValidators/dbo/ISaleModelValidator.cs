using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface ISaleModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(SaleModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, SaleModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dfb98659272dd9b6bfcb3492a9e7c817</Hash>
</Codenesium>*/