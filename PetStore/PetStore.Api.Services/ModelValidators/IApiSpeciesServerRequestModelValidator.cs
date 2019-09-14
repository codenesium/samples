using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IApiSpeciesServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSpeciesServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpeciesServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0ec2e045bfb07a12945e896f763f7b91</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/