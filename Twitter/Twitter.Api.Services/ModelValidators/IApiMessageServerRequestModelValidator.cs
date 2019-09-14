using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

namespace TwitterNS.Api.Services
{
	public partial interface IApiMessageServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiMessageServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiMessageServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dd20a5a5f57ed87e5fea1f89fc3fb60e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/