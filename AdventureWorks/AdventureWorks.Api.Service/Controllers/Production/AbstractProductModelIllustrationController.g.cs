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
	public abstract class AbstractProductModelIllustrationController: AbstractApiController
	{
		protected IBOProductModelIllustration productModelIllustrationManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractProductModelIllustrationController(
			ServiceSettings settings,
			ILogger<AbstractProductModelIllustrationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductModelIllustration productModelIllustrationManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.productModelIllustrationManager = productModelIllustrationManager;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<POCOProductModelIllustration>), 200)]
		public async virtual Task<IActionResult> All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<POCOProductModelIllustration> response = await this.productModelIllustrationManager.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(POCOProductModelIllustration), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			POCOProductModelIllustration response = await this.productModelIllustrationManager.Get(id);

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
		[ProducesResponseType(typeof(POCOProductModelIllustration), 200)]
		[ProducesResponseType(typeof(CreateResponse<int>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiProductModelIllustrationModel model)
		{
			CreateResponse<POCOProductModelIllustration> result = await this.productModelIllustrationManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.ProductModelID.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/ProductModelIllustrations/{result.Record.ProductModelID.ToString()}");
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
		[ProducesResponseType(typeof(List<POCOProductModelIllustration>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiProductModelIllustrationModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<POCOProductModelIllustration> records = new List<POCOProductModelIllustration>();
			foreach (var model in models)
			{
				CreateResponse<POCOProductModelIllustration> result = await this.productModelIllustrationManager.Create(model);

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
		[ProducesResponseType(typeof(POCOProductModelIllustration), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiProductModelIllustrationModel model)
		{
			try
			{
				ActionResponse result = await this.productModelIllustrationManager.Update(id, model);

				if (result.Success)
				{
					POCOProductModelIllustration response = await this.productModelIllustrationManager.Get(id);

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
			ActionResponse result = await this.productModelIllustrationManager.Delete(id);

			if (result.Success)
			{
				return this.NoContent();
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}
	}
}

/*<Codenesium>
    <Hash>ce4f7cec8fe9b328b2e6b9118377f855</Hash>
</Codenesium>*/