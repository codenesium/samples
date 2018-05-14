using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	public abstract class AbstractEmployeeController: AbstractApiController
	{
		protected IBOEmployee employeeManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractEmployeeController(
			ServiceSettings settings,
			ILogger<AbstractEmployeeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOEmployee employeeManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.employeeManager = employeeManager;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOEmployee>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<POCOEmployee> response = this.employeeManager.All(query.Offset, query.Limit);

			if (response.Count == 0)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOEmployee), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Get(int id)
		{
			POCOEmployee response = this.employeeManager.Get(id);
			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOEmployee), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiEmployeeModel model)
		{
			CreateResponse<POCOEmployee> result = await this.employeeManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.BusinessEntityID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/Employees/{result.Record.BusinessEntityID.ToString()}");
				return this.Ok(result.Record);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<POCOEmployee>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiEmployeeModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<POCOEmployee> records = new List<POCOEmployee>();
			foreach (var model in models)
			{
				CreateResponse<POCOEmployee> result = await this.employeeManager.Create(model);

				if(result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			return this.Ok(records);
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOEmployee), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiEmployeeModel model)
		{
			try
			{
				ActionResponse result = await this.employeeManager.Update(id, model);

				if (result.Success)
				{
					POCOEmployee response = this.employeeManager.Get(id);
					return this.Ok(response);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
			catch(RecordNotFoundException)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.employeeManager.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("getLoginID/{loginID}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOEmployee), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult GetLoginID(string loginID)
		{
			POCOEmployee response = this.employeeManager.GetLoginID(loginID);
			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpGet]
		[Route("getNationalIDNumber/{nationalIDNumber}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOEmployee), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult GetNationalIDNumber(string nationalIDNumber)
		{
			POCOEmployee response = this.employeeManager.GetNationalIDNumber(nationalIDNumber);
			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpGet]
		[Route("getOrganizationLevelOrganizationNode/{organizationLevel}/{organizationNode}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOEmployee>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult GetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel,Nullable<Guid> organizationNode)
		{
			List<POCOEmployee> response = this.employeeManager.GetOrganizationLevelOrganizationNode(organizationLevel,organizationNode);
			if (response.Count == 0)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		[HttpGet]
		[Route("getOrganizationNode/{organizationNode}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOEmployee>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult GetOrganizationNode(Nullable<Guid> organizationNode)
		{
			List<POCOEmployee> response = this.employeeManager.GetOrganizationNode(organizationNode);
			if (response.Count == 0)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}
	}
}

/*<Codenesium>
    <Hash>58d487c3168f95573da864ea9e0b4d20</Hash>
</Codenesium>*/