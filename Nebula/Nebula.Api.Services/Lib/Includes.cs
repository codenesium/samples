using FluentValidation.Results;
using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NebulaNS.Api.Services
{
	public class RouteConstants
	{public const string Chains = "chains";
	 public const string ChainStatuses = "chainstatuses";
	 public const string Clasps = "clasps";
	 public const string Links = "links";
	 public const string LinkLogs = "linklogs";
	 public const string LinkStatuses = "linkstatuses";
	 public const string Machines = "machines";
	 public const string MachineRefTeams = "machinerefteams";
	 public const string Organizations = "organizations";
	 public const string Sysdiagrams = "sysdiagrams";
	 public const string Teams = "teams";
	 public const string VersionInfoes = "versioninfoes";}

	public abstract class AbstractService
	{
	}

	public abstract class AbstractBusinessObject
	{
	}

	public static class ValidationResponseFactory<T>
	{
		public static CreateResponse<T> CreateResponse(T record)
		{
			return new CreateResponse<T>(record);
		}

		public static CreateResponse<T> CreateResponse(ValidationResult result)
		{
			var response = new CreateResponse<T>();
			response.Success = result.IsValid;
			foreach (ValidationFailure error in result.Errors)
			{
				response.ValidationErrors.Add(new ValidationError(error.ErrorCode, error.ErrorMessage, error.PropertyName));
			}

			return response;
		}

		public static UpdateResponse<T> UpdateResponse(T record)
		{
			return new UpdateResponse<T>(record);
		}

		public static UpdateResponse<T> UpdateResponse(ValidationResult result)
		{
			var response = new UpdateResponse<T>();
			response.Success = result.IsValid;
			foreach (ValidationFailure error in result.Errors)
			{
				response.ValidationErrors.Add(new ValidationError(error.ErrorCode, error.ErrorMessage, error.PropertyName));
			}

			return response;
		}

		public static ActionResponse ActionResponse(ValidationResult result)
		{
			var response = new ActionResponse();
			response.Success = result.IsValid;
			foreach (ValidationFailure error in result.Errors)
			{
				response.ValidationErrors.Add(new ValidationError(error.ErrorCode, error.ErrorMessage, error.PropertyName));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>48416a4d7355b925d35a2ef6eebb6295</Hash>
</Codenesium>*/