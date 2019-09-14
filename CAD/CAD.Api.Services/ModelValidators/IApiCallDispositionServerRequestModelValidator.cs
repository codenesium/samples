using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiCallDispositionServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCallDispositionServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiCallDispositionServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>0ce5bbb21b056c5fa2e98309f7a8ccab</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/