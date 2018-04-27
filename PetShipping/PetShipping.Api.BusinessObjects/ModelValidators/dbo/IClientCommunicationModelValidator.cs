using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.BusinessObjects
{
	public interface IClientCommunicationModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(ClientCommunicationModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, ClientCommunicationModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>738bc87a20172152bb09f157d3c7fc8f</Hash>
</Codenesium>*/