using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IClientCommunicationModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ClientCommunicationModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ClientCommunicationModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>baa1876938ffe92e5a3d7bf7597a6db7</Hash>
</Codenesium>*/