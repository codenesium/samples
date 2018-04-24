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
using NebulaNS.Api.Contracts;
using NebulaNS.Api.BusinessObjects;

namespace NebulaNS.Api.Service
{
	public abstract class AbstractClaspController: AbstractApiController
	{
		protected IBOClasp claspManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractClaspController(
			ServiceSettings settings,
			ILogger<AbstractClaspController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOClasp claspManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.claspManager = claspManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOClasp), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Get(int id)
		{
			POCOClasp response = this.claspManager.GetById(id).Clasps.FirstOrDefault();
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
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOClasp>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public virtual IActionResult Search()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			ApiResponse response = this.claspManager.GetWhereDynamic(query.WhereClause, query.Offset, query.Limit);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.Clasps);
			}
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOClasp), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ClaspModel model)
		{
			CreateResponse<int> result = await this.claspManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Id.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/clasps/{result.Id.ToString()}");
				POCOClasp response = this.claspManager.GetById(result.Id).Clasps.First();
				return this.Ok(response);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPost]
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(List<int>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ClaspModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<int> ids = new List<int>();
			foreach (var model in models)
			{
				CreateResponse<int> result = await this.claspManager.Create(model);

				if(result.Success)
				{
					ids.Add(result.Id);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			return this.Ok(ids);
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(POCOClasp), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ClaspModel model)
		{
			try
			{
				ActionResponse result = await this.claspManager.Update(id, model);

				if (result.Success)
				{
					POCOClasp response = this.claspManager.GetById(id).Clasps.First();
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
			ActionResponse result = await this.claspManager.Delete(id);

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
		[Route("ByPreviousChainId/{id}")]
		[ReadOnly]
		[Route("~/api/Chains/{id}/Clasps")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOClasp>), 200)]
		public virtual IActionResult ByPreviousChainId(int id)
		{
			ApiResponse response = this.claspManager.GetWhere(x => x.PreviousChainId == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.Clasps);
			}
		}

		[HttpGet]
		[Route("ByNextChainId/{id}")]
		[ReadOnly]
		[Route("~/api/Chains/{id}/Clasps")]
		[ProducesResponseType(typeof(ApiResponse), 200)]
		[ProducesResponseType(typeof(List<POCOClasp>), 200)]
		public virtual IActionResult ByNextChainId(int id)
		{
			ApiResponse response = this.claspManager.GetWhere(x => x.NextChainId == id);

			if (this.Request.HttpContext.Request.Headers.Any(x => x.Key == "x-include-references" && x.Value == "1"))
			{
				return this.Ok(response);
			}
			else
			{
				return this.Ok(response.Clasps);
			}
		}
	}
}

/*<Codenesium>
    <Hash>53babf96fbc6f6ffda0027fd60f52094</Hash>
</Codenesium>*/