using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IApiClaspRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClaspRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClaspRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>de5dce30cfae72003e4bce328dc5d8b2</Hash>
</Codenesium>*/