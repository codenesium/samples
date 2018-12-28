using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Services
{
	public class RouteConstants
	{public const string Admins = "admins";
	 public const string Cities = "cities";
	 public const string Countries = "countries";
	 public const string Customers = "customers";
	 public const string Events = "events";
	 public const string Provinces = "provinces";
	 public const string Sales = "sales";
	 public const string SaleTickets = "saletickets";
	 public const string Tickets = "tickets";
	 public const string TicketStatus = "ticketstatus";
	 public const string Transactions = "transactions";
	 public const string TransactionStatus = "transactionstatus";
	 public const string Venues = "venues";}

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
    <Hash>cb0d83d154be52c2edb7df006c986e2d</Hash>
</Codenesium>*/