using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiLocationServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLocationServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiLocationServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f63a28578074205d2954ff55a715cd50</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/