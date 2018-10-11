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
	public abstract class AbstractVStateProvinceCountryRegionController : AbstractApiController
	{
		protected IVStateProvinceCountryRegionService VStateProvinceCountryRegionService { get; private set; }

		protected IApiVStateProvinceCountryRegionModelMapper VStateProvinceCountryRegionModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractVStateProvinceCountryRegionController(
			ApiSettings settings,
			ILogger<AbstractVStateProvinceCountryRegionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IVStateProvinceCountryRegionService vStateProvinceCountryRegionService,
			IApiVStateProvinceCountryRegionModelMapper vStateProvinceCountryRegionModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.VStateProvinceCountryRegionService = vStateProvinceCountryRegionService;
			this.VStateProvinceCountryRegionModelMapper = vStateProvinceCountryRegionModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiVStateProvinceCountryRegionResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			if (!query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value)))
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge, query.Error);
			}

			List<ApiVStateProvinceCountryRegionResponseModel> response = await this.VStateProvinceCountryRegionService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiVStateProvinceCountryRegionResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiVStateProvinceCountryRegionResponseModel response = await this.VStateProvinceCountryRegionService.Get(id);

			if (response == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				return this.Ok(response);
			}
		}

		private async Task<ApiVStateProvinceCountryRegionRequestModel> PatchModel(int id, JsonPatchDocument<ApiVStateProvinceCountryRegionRequestModel> patch)
		{
			var record = await this.VStateProvinceCountryRegionService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiVStateProvinceCountryRegionRequestModel request = this.VStateProvinceCountryRegionModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>bd15479097314eb252248e0de4684e17</Hash>
</Codenesium>*/