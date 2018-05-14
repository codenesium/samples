using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IApiDestinationModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiDestinationModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiDestinationModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0fd0acd2c039bbc115bad7b39558fd65</Hash>
</Codenesium>*/