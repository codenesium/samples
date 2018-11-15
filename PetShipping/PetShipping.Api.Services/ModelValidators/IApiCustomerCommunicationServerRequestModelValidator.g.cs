using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiCustomerCommunicationServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCustomerCommunicationServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerCommunicationServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>4b4c7d6bd608a7ac4d595c6a03db79c7</Hash>
</Codenesium>*/