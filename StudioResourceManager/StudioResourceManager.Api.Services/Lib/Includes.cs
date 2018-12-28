using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudioResourceManagerNS.Api.Services
{
	public class RouteConstants
	{public const string Admins = "admins";
	 public const string Events = "events";
	 public const string EventStatus = "eventstatus";
	 public const string EventStudents = "eventstudents";
	 public const string EventTeachers = "eventteachers";
	 public const string Families = "families";
	 public const string Rates = "rates";
	 public const string Spaces = "spaces";
	 public const string SpaceFeatures = "spacefeatures";
	 public const string SpaceSpaceFeatures = "spacespacefeatures";
	 public const string Students = "students";
	 public const string Studios = "studios";
	 public const string Teachers = "teachers";
	 public const string TeacherSkills = "teacherskills";
	 public const string TeacherTeacherSkills = "teacherteacherskills";
	 public const string Users = "users";}

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
    <Hash>abadce907f5b4ea2075a16cd048f6050</Hash>
</Codenesium>*/