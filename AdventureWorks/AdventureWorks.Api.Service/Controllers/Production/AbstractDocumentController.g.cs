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
	public abstract class AbstractDocumentController: AbstractApiController
	{
		protected IBODocument documentManager;

		protected int BulkInsertLimit { get; set; }

		protected int SearchRecordLimit { get; set; }

		protected int SearchRecordDefault { get; set; }

		public AbstractDocumentController(
			ServiceSettings settings,
			ILogger<AbstractDocumentController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBODocument documentManager
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.documentManager = documentManager;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDocumentResponseModel>), 200)]
		public async virtual Task<IActionResult> All()
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.SearchRecordLimit, this.SearchRecordDefault, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiDocumentResponseModel> response = await this.documentManager.All(query.Offset, query.Limit);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiDocumentResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(Guid id)
		{
			ApiDocumentResponseModel response = await this.documentManager.Get(id);

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
		[ProducesResponseType(typeof(ApiDocumentResponseModel), 200)]
		[ProducesResponseType(typeof(CreateResponse<Guid>), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiDocumentRequestModel model)
		{
			CreateResponse<ApiDocumentResponseModel> result = await this.documentManager.Create(model);

			if (result.Success)
			{
				this.Request.HttpContext.Response.Headers.Add("x-record-id", result.Record.DocumentNode.ToString());
				this.Request.HttpContext.Response.Headers.Add("Location", $"{this.Settings.ExternalBaseUrl}/api/Documents/{result.Record.DocumentNode.ToString()}");
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
		[ProducesResponseType(typeof(List<ApiDocumentResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiDocumentRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiDocumentResponseModel> records = new List<ApiDocumentResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiDocumentResponseModel> result = await this.documentManager.Create(model);

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
		[ProducesResponseType(typeof(DTODocument), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(Guid id, [FromBody] ApiDocumentRequestModel model)
		{
			try
			{
				ActionResponse result = await this.documentManager.Update(id, model);

				if (result.Success)
				{
					ApiDocumentResponseModel response = await this.documentManager.Get(id);

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
		public virtual async Task<IActionResult> Delete(Guid id)
		{
			ActionResponse result = await this.documentManager.Delete(id);

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
		[Route("getDocumentLevelDocumentNode/{documentLevel}/{documentNode}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiDocumentResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> GetDocumentLevelDocumentNode(Nullable<short> documentLevel,Guid documentNode)
		{
			ApiDocumentResponseModel response = await this.documentManager.GetDocumentLevelDocumentNode(documentLevel,documentNode);

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
		[Route("getFileNameRevision/{fileName}/{revision}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiDocumentResponseModel>), 200)]
		public async virtual Task<IActionResult> GetFileNameRevision(string fileName,string revision)
		{
			List<ApiDocumentResponseModel> response = await this.documentManager.GetFileNameRevision(fileName,revision);

			return this.Ok(response);
		}
	}
}

/*<Codenesium>
    <Hash>e003b4e85f04f174b37203782e40fdf5</Hash>
</Codenesium>*/