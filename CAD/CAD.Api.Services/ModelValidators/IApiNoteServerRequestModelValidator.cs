using CADNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiNoteServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiNoteServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiNoteServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6cacc392b1a04fb60cc7e77befbeb30f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/