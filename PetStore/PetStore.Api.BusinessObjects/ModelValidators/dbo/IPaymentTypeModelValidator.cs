using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IPaymentTypeModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(PaymentTypeModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, PaymentTypeModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>5b408384508de2e811ef61a59f931692</Hash>
</Codenesium>*/