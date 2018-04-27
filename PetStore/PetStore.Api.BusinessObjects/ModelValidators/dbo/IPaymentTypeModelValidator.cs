using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.BusinessObjects
{
	public interface IPaymentTypeModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(PaymentTypeModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, PaymentTypeModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>203758f35023190f413910e2d89a0f55</Hash>
</Codenesium>*/