using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
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

namespace AdventureWorksNS.Api.Web
{
        public abstract class AbstractBillOfMaterialController : AbstractApiController
        {
                protected IBillOfMaterialService BillOfMaterialService { get; private set; }

                protected IApiBillOfMaterialModelMapper BillOfMaterialModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractBillOfMaterialController(
                        ApiSettings settings,
                        ILogger<AbstractBillOfMaterialController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBillOfMaterialService billOfMaterialService,
                        IApiBillOfMaterialModelMapper billOfMaterialModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.BillOfMaterialService = billOfMaterialService;
                        this.BillOfMaterialModelMapper = billOfMaterialModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiBillOfMaterialResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiBillOfMaterialResponseModel> response = await this.BillOfMaterialService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiBillOfMaterialResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiBillOfMaterialResponseModel response = await this.BillOfMaterialService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiBillOfMaterialResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiBillOfMaterialRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiBillOfMaterialResponseModel> records = new List<ApiBillOfMaterialResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiBillOfMaterialResponseModel> result = await this.BillOfMaterialService.Create(model);

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
                [ProducesResponseType(typeof(CreateResponse<ApiBillOfMaterialResponseModel>), 201)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiBillOfMaterialRequestModel model)
                {
                        CreateResponse<ApiBillOfMaterialResponseModel> result = await this.BillOfMaterialService.Create(model);

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
                [ProducesResponseType(typeof(UpdateResponse<ApiBillOfMaterialResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiBillOfMaterialRequestModel> patch)
                {
                        ApiBillOfMaterialResponseModel record = await this.BillOfMaterialService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiBillOfMaterialRequestModel model = await this.PatchModel(id, patch);

                                UpdateResponse<ApiBillOfMaterialResponseModel> result = await this.BillOfMaterialService.Update(id, model);

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
                [ProducesResponseType(typeof(UpdateResponse<ApiBillOfMaterialResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiBillOfMaterialRequestModel model)
                {
                        ApiBillOfMaterialRequestModel request = await this.PatchModel(id, this.BillOfMaterialModelMapper.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                UpdateResponse<ApiBillOfMaterialResponseModel> result = await this.BillOfMaterialService.Update(id, request);

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
                        ActionResponse result = await this.BillOfMaterialService.Delete(id);

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
                [Route("byProductAssemblyIDComponentIDStartDate/{productAssemblyID}/{componentID}/{startDate}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiBillOfMaterialResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByProductAssemblyIDComponentIDStartDate(int? productAssemblyID, int componentID, DateTime startDate)
                {
                        ApiBillOfMaterialResponseModel response = await this.BillOfMaterialService.ByProductAssemblyIDComponentIDStartDate(productAssemblyID, componentID, startDate);

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
                [Route("byUnitMeasureCode/{unitMeasureCode}")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiBillOfMaterialResponseModel>), 200)]
                public async virtual Task<IActionResult> ByUnitMeasureCode(string unitMeasureCode)
                {
                        List<ApiBillOfMaterialResponseModel> response = await this.BillOfMaterialService.ByUnitMeasureCode(unitMeasureCode);

                        return this.Ok(response);
                }

                private async Task<ApiBillOfMaterialRequestModel> PatchModel(int id, JsonPatchDocument<ApiBillOfMaterialRequestModel> patch)
                {
                        var record = await this.BillOfMaterialService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiBillOfMaterialRequestModel request = this.BillOfMaterialModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>5a9a5e5ea5ac50021811165e3e8f6ecf</Hash>
</Codenesium>*/