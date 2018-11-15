using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	public abstract class AbstractBillOfMaterialController : AbstractApiController
	{
		protected IBillOfMaterialService BillOfMaterialService { get; private set; }

		protected IApiBillOfMaterialServerModelMapper BillOfMaterialModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractBillOfMaterialController(
			ApiSettings settings,
			ILogger<AbstractBillOfMaterialController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBillOfMaterialService billOfMaterialService,
			IApiBillOfMaterialServerModelMapper billOfMaterialModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.BillOfMaterialService = billOfMaterialService;
			this.BillOfMaterialModelMapper = billOfMaterialModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiBillOfMaterialServerResponseModel>), 200)]

		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiBillOfMaterialServerResponseModel> response = await this.BillOfMaterialService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiBillOfMaterialServerResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]

		public async virtual Task<IActionResult> Get(int id)
		{
			ApiBillOfMaterialServerResponseModel response = await this.BillOfMaterialService.Get(id);

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
		[Route("BulkInsert")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<List<ApiBillOfMaterialServerResponseModel>>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiBillOfMaterialServerRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiBillOfMaterialServerResponseModel> records = new List<ApiBillOfMaterialServerResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiBillOfMaterialServerResponseModel> result = await this.BillOfMaterialService.Create(model);

				if (result.Success)
				{
					records.Add(result.Record);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}

			var response = new CreateResponse<List<ApiBillOfMaterialServerResponseModel>>();
			response.SetRecord(records);

			return this.Ok(response);
		}

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiBillOfMaterialServerResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Create([FromBody] ApiBillOfMaterialServerRequestModel model)
		{
			CreateResponse<ApiBillOfMaterialServerResponseModel> result = await this.BillOfMaterialService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/BillOfMaterials/{result.Record.BillOfMaterialsID}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiBillOfMaterialServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiBillOfMaterialServerRequestModel> patch)
		{
			ApiBillOfMaterialServerResponseModel record = await this.BillOfMaterialService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiBillOfMaterialServerRequestModel model = await this.PatchModel(id, patch) as ApiBillOfMaterialServerRequestModel;

				UpdateResponse<ApiBillOfMaterialServerResponseModel> result = await this.BillOfMaterialService.Update(id, model);

				if (result.Success)
				{
					return this.Ok(result);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
		}

		[HttpPut]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiBillOfMaterialServerResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiBillOfMaterialServerRequestModel model)
		{
			ApiBillOfMaterialServerRequestModel request = await this.PatchModel(id, this.BillOfMaterialModelMapper.CreatePatch(model)) as ApiBillOfMaterialServerRequestModel;

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiBillOfMaterialServerResponseModel> result = await this.BillOfMaterialService.Update(id, request);

				if (result.Success)
				{
					return this.Ok(result);
				}
				else
				{
					return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
				}
			}
		}

		[HttpDelete]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(ActionResponse), 200)]
		[ProducesResponseType(typeof(ActionResponse), 422)]

		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.BillOfMaterialService.Delete(id);

			if (result.Success)
			{
				return this.StatusCode(StatusCodes.Status200OK, result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpGet]
		[Route("byUnitMeasureCode/{unitMeasureCode}")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiBillOfMaterialServerResponseModel>), 200)]
		public async virtual Task<IActionResult> ByUnitMeasureCode(string unitMeasureCode, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiBillOfMaterialServerResponseModel> response = await this.BillOfMaterialService.ByUnitMeasureCode(unitMeasureCode, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiBillOfMaterialServerRequestModel> PatchModel(int id, JsonPatchDocument<ApiBillOfMaterialServerRequestModel> patch)
		{
			var record = await this.BillOfMaterialService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiBillOfMaterialServerRequestModel request = this.BillOfMaterialModelMapper.MapServerResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>435f3e7d695680c119fd7da2fcc34a63</Hash>
</Codenesium>*/