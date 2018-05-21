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
	public abstract class AbstractUnitMeasureController: AbstractApiController
	{
		protected IBOUnitMeasure unitMeasureManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractUnitMeasureController(
			ServiceSettings settings,
			ILogger<AbstractUnitMeasureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOUnitMeasure unitMeasureManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.unitMeasureManager = unitMeasureManager;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOUnitMeasure>), 200)]
		public async virtual Task<IActionResult> All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<POCOUnitMeasure> response = await this.unitMeasureManager.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOUnitMeasure), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(string id)
		{
			POCOUnitMeasure response = await this.unitMeasureManager.Get(id);

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
		[ProducesResponseType(typeof(POCOUnitMeasure), 200)]
		[ProducesResponseType(typeof(CreateResponse<string>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiUnitMeasureModel model)
		{
			CreateResponse<POCOUnitMeasure> result = await this.unitMeasureManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.UnitMeasureCode.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/UnitMeasures/{result.Record.UnitMeasureCode.ToString()}");
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
		[ProducesResponseType(typeof(List<POCOUnitMeasure>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiUnitMeasureModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<POCOUnitMeasure> records = new List<POCOUnitMeasure>();
			foreach (var model in models)
			{
				CreateResponse<POCOUnitMeasure> result = await this.unitMeasureManager.Create(model);

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
		[ProducesResponseType(typeof(POCOUnitMeasure), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(string id, [FromBody] ApiUnitMeasureModel model)
		{
			try
			{
				ActionResponse result = await this.unitMeasureManager.Update(id, model);

				if (result.Success)
				{
					POCOUnitMeasure response = await this.unitMeasureManager.Get(id);

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
		public virtual async Task<IActionResult> Delete(string id)
		{
			ActionResponse result = await this.unitMeasureManager.Delete(id);

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
		[Route("getName/{name}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOUnitMeasure), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> GetName(string name)
		{
			POCOUnitMeasure response = await this.unitMeasureManager.GetName(name);

			if (response == null)
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
    <Hash>351b87d77b88403eef34e303dce70e17</Hash>
</Codenesium>*/