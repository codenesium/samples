using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShippingNS.Api.Services
{
	public class RouteConstants
	{public const string Airlines = "airlines";
	 public const string AirTransports = "airtransports";
	 public const string Breeds = "breeds";
	 public const string Countries = "countries";
	 public const string CountryRequirements = "countryrequirements";
	 public const string Customers = "customers";
	 public const string CustomerCommunications = "customercommunications";
	 public const string Destinations = "destinations";
	 public const string Employees = "employees";
	 public const string Handlers = "handlers";
	 public const string HandlerPipelineSteps = "handlerpipelinesteps";
	 public const string OtherTransports = "othertransports";
	 public const string Pets = "pets";
	 public const string Pipelines = "pipelines";
	 public const string PipelineStatus = "pipelinestatus";
	 public const string PipelineSteps = "pipelinesteps";
	 public const string PipelineStepDestinations = "pipelinestepdestinations";
	 public const string PipelineStepNotes = "pipelinestepnotes";
	 public const string PipelineStepStatus = "pipelinestepstatus";
	 public const string PipelineStepStepRequirements = "pipelinestepsteprequirements";
	 public const string Sales = "sales";
	 public const string Species = "species";}

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
    <Hash>9247f4cd54f6ad4ad0121cc0f2a6d771</Hash>
</Codenesium>*/