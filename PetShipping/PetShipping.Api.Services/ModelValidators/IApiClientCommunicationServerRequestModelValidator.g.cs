using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiClientCommunicationServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClientCommunicationServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientCommunicationServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d0703f49995bacda3d4510515df4f356</Hash>
</Codenesium>*/