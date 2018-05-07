using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IDestinationModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(DestinationModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, DestinationModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>c1fdd51b7bb29ae337bfdf7152579057</Hash>
</Codenesium>*/