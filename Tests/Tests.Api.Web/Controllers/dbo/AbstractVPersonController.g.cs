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
using TestsNS.Api.Contracts;
using TestsNS.Api.Services;

namespace TestsNS.Api.Web
{
	public abstract class AbstractVPersonController : AbstractApiController
	{
		protected IVPersonService VPersonService { get; private set; }

		protected IApiVPersonModelMapper VPersonModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractVPersonController(
			ApiSettings settings,
			ILogger<AbstractVPersonController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVPersonService vPersonService,
			IApiVPersonModelMapper vPersonModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.VPersonService = vPersonService;
			this.VPersonModelMapper = vPersonModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVPersonResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiVPersonResponseModel> response = await this.VPersonService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiVPersonResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiVPersonResponseModel response = await this.VPersonService.Get(id);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		private async Task<ApiVPersonRequestModel> PatchModel(int id, JsonPatchDocument<ApiVPersonRequestModel> patch)
		{
			var record = await this.VPersonService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiVPersonRequestModel request = this.VPersonModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>e3c01b0d185782b64db6e1b091f1017c</Hash>
</Codenesium>*/