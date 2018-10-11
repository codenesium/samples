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
	public abstract class AbstractVProductAndDescriptionController : AbstractApiController
	{
		protected IVProductAndDescriptionService VProductAndDescriptionService { get; private set; }

		protected IApiVProductAndDescriptionModelMapper VProductAndDescriptionModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractVProductAndDescriptionController(
			ApiSettings settings,
			ILogger<AbstractVProductAndDescriptionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVProductAndDescriptionService vProductAndDescriptionService,
			IApiVProductAndDescriptionModelMapper vProductAndDescriptionModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.VProductAndDescriptionService = vProductAndDescriptionService;
			this.VProductAndDescriptionModelMapper = vProductAndDescriptionModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVProductAndDescriptionResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiVProductAndDescriptionResponseModel> response = await this.VProductAndDescriptionService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiVProductAndDescriptionResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(string id)
		{
			ApiVProductAndDescriptionResponseModel response = await this.VProductAndDescriptionService.Get(id);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		private async Task<ApiVProductAndDescriptionRequestModel> PatchModel(string id, JsonPatchDocument<ApiVProductAndDescriptionRequestModel> patch)
		{
			var record = await this.VProductAndDescriptionService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiVProductAndDescriptionRequestModel request = this.VProductAndDescriptionModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>6b7792c5a80f7565409360a0ee2b37ce</Hash>
</Codenesium>*/