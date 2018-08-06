using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NebulaNS.Api.Web
{
	public abstract class AbstractMachineController : AbstractApiController
	{
		protected IMachineService MachineService { get; private set; }

		protected IApiMachineModelMapper MachineModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractMachineController(
			ApiSettings settings,
			ILogger<AbstractMachineController> logger,
			ITransactionCoordinator transactionCoordinator,
			IMachineService machineService,
			IApiMachineModelMapper machineModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.MachineService = machineService;
			this.MachineModelMapper = machineModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiMachineResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiMachineResponseModel> response = await this.MachineService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiMachineResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiMachineResponseModel response = await this.MachineService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiMachineResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiMachineRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiMachineResponseModel> records = new List<ApiMachineResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiMachineResponseModel> result = await this.MachineService.Create(model);

				if (result.Success)
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

		[HttpPost]
		[Route("")]
		[UnitOfWork]
		[ProducesResponseType(typeof(CreateResponse<ApiMachineResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiMachineRequestModel model)
		{
			CreateResponse<ApiMachineResponseModel> result = await this.MachineService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Machines/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiMachineResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiMachineRequestModel> patch)
		{
			ApiMachineResponseModel record = await this.MachineService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiMachineRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiMachineResponseModel> result = await this.MachineService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiMachineResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiMachineRequestModel model)
		{
			ApiMachineRequestModel request = await this.PatchModel(id, this.MachineModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiMachineResponseModel> result = await this.MachineService.Update(id, request);

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
		[ProducesResponseType(typeof(void), 204)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Delete(int id)
		{
			ActionResponse result = await this.MachineService.Delete(id);

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
		[Route("{assignedMachineId}/Links")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiLinkResponseModel>), 200)]
		public async virtual Task<IActionResult> Links(int assignedMachineId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiLinkResponseModel> response = await this.MachineService.Links(assignedMachineId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{machineId}/MachineRefTeams")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiMachineRefTeamResponseModel>), 200)]
		public async virtual Task<IActionResult> MachineRefTeams(int machineId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiMachineRefTeamResponseModel> response = await this.MachineService.MachineRefTeams(machineId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiMachineRequestModel> PatchModel(int id, JsonPatchDocument<ApiMachineRequestModel> patch)
		{
			var record = await this.MachineService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiMachineRequestModel request = this.MachineModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>061ae76ee8ad877e95b318ad5a9db0e5</Hash>
</Codenesium>*/