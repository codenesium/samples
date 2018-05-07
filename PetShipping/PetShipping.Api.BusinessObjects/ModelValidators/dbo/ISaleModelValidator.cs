using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface ISaleModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(SaleModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, SaleModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d6c9653953d6bbafc84e7d2068c29332</Hash>
</Codenesium>*/