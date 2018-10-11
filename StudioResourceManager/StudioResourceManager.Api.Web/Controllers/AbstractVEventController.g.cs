using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Web
{
	public abstract class AbstractVEventController : AbstractApiController
	{
		protected IVEventService VEventService { get; private set; }

		protected IApiVEventModelMapper VEventModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractVEventController(
			ApiSettings settings,
			ILogger<AbstractVEventController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVEventService vEventService,
			IApiVEventModelMapper vEventModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.VEventService = vEventService;
			this.VEventModelMapper = vEventModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVEventResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiVEventResponseModel> response = await this.VEventService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiVEventResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiVEventResponseModel response = await this.VEventService.Get(id);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		private async Task<ApiVEventRequestModel> PatchModel(int id, JsonPatchDocument<ApiVEventRequestModel> patch)
		{
			var record = await this.VEventService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiVEventRequestModel request = this.VEventModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>d06abd5aab57de26d29e1612d1583d46</Hash>
</Codenesium>*/