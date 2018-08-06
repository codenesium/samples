using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentValidation.Results;
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

namespace FermataFishNS.Api.Web
{
	public abstract class AbstractFamilyController : AbstractApiController
	{
		protected IFamilyService FamilyService { get; private set; }

		protected IApiFamilyModelMapper FamilyModelMapper { get; private set; }

		protected int BulkInsertLimit { get; set; }

		protected int MaxLimit { get; set; }

		protected int DefaultLimit { get; set; }

		public AbstractFamilyController(
			ApiSettings settings,
			ILogger<AbstractFamilyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFamilyService familyService,
			IApiFamilyModelMapper familyModelMapper
			)
			: base(settings, logger, transactionCoordinator)
		{
			this.FamilyService = familyService;
			this.FamilyModelMapper = familyModelMapper;
		}

		[HttpGet]
		[Route("")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiFamilyResponseModel>), 200)]
		public async virtual Task<IActionResult> All(int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();
			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiFamilyResponseModel> response = await this.FamilyService.All(query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		[ReadOnly]
		[ProducesResponseType(typeof(ApiFamilyResponseModel), 200)]
		[ProducesResponseType(typeof(void), 404)]
		public async virtual Task<IActionResult> Get(int id)
		{
			ApiFamilyResponseModel response = await this.FamilyService.Get(id);

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
		[ProducesResponseType(typeof(List<ApiFamilyResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 413)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiFamilyRequestModel> models)
		{
			if (models.Count > this.BulkInsertLimit)
			{
				return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
			}

			List<ApiFamilyResponseModel> records = new List<ApiFamilyResponseModel>();
			foreach (var model in models)
			{
				CreateResponse<ApiFamilyResponseModel> result = await this.FamilyService.Create(model);

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
		[ProducesResponseType(typeof(CreateResponse<ApiFamilyResponseModel>), 201)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Create([FromBody] ApiFamilyRequestModel model)
		{
			CreateResponse<ApiFamilyResponseModel> result = await this.FamilyService.Create(model);

			if (result.Success)
			{
				return this.Created($"{this.Settings.ExternalBaseUrl}/api/Families/{result.Record.Id}", result);
			}
			else
			{
				return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
			}
		}

		[HttpPatch]
		[Route("{id}")]
		[UnitOfWork]
		[ProducesResponseType(typeof(UpdateResponse<ApiFamilyResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiFamilyRequestModel> patch)
		{
			ApiFamilyResponseModel record = await this.FamilyService.Get(id);

			if (record == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				ApiFamilyRequestModel model = await this.PatchModel(id, patch);

				UpdateResponse<ApiFamilyResponseModel> result = await this.FamilyService.Update(id, model);

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
		[ProducesResponseType(typeof(UpdateResponse<ApiFamilyResponseModel>), 200)]
		[ProducesResponseType(typeof(void), 404)]
		[ProducesResponseType(typeof(ActionResponse), 422)]
		public virtual async Task<IActionResult> Update(int id, [FromBody] ApiFamilyRequestModel model)
		{
			ApiFamilyRequestModel request = await this.PatchModel(id, this.FamilyModelMapper.CreatePatch(model));

			if (request == null)
			{
				return this.StatusCode(StatusCodes.Status404NotFound);
			}
			else
			{
				UpdateResponse<ApiFamilyResponseModel> result = await this.FamilyService.Update(id, request);

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
			ActionResponse result = await this.FamilyService.Delete(id);

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
		[Route("{familyId}/Students")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiStudentResponseModel>), 200)]
		public async virtual Task<IActionResult> Students(int familyId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiStudentResponseModel> response = await this.FamilyService.Students(familyId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		[HttpGet]
		[Route("{familyId}/StudentXFamilies")]
		[ReadOnly]
		[ProducesResponseType(typeof(List<ApiStudentXFamilyResponseModel>), 200)]
		public async virtual Task<IActionResult> StudentXFamilies(int familyId, int? limit, int? offset)
		{
			SearchQuery query = new SearchQuery();

			query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
			List<ApiStudentXFamilyResponseModel> response = await this.FamilyService.StudentXFamilies(familyId, query.Limit, query.Offset);

			return this.Ok(response);
		}

		private async Task<ApiFamilyRequestModel> PatchModel(int id, JsonPatchDocument<ApiFamilyRequestModel> patch)
		{
			var record = await this.FamilyService.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				ApiFamilyRequestModel request = this.FamilyModelMapper.MapResponseToRequest(record);
				patch.ApplyTo(request);
				return request;
			}
		}
	}
}

/*<Codenesium>
    <Hash>afad6365ed5be04c78b1d6484fd5671d</Hash>
</Codenesium>*/