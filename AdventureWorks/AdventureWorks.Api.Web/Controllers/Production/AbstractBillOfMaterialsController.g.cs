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
        public abstract class AbstractBillOfMaterialsController : AbstractApiController
        {
                protected IBillOfMaterialsService BillOfMaterialsService { get; private set; }

                protected IApiBillOfMaterialsModelMapper BillOfMaterialsModelMapper { get; private set; }

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractBillOfMaterialsController(
                        ApiSettings settings,
                        ILogger<AbstractBillOfMaterialsController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBillOfMaterialsService billOfMaterialsService,
                        IApiBillOfMaterialsModelMapper billOfMaterialsModelMapper
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.BillOfMaterialsService = billOfMaterialsService;
                        this.BillOfMaterialsModelMapper = billOfMaterialsModelMapper;
                }

                [HttpGet]
                [Route("")]
                [ReadOnly]
                [ProducesResponseType(typeof(List<ApiBillOfMaterialsResponseModel>), 200)]
                public async virtual Task<IActionResult> All(int? limit, int? offset)
                {
                        SearchQuery query = new SearchQuery();
                        query.Process(this.MaxLimit, this.DefaultLimit, limit, offset, this.ControllerContext.HttpContext.Request.Query.ToDictionary(q => q.Key, q => q.Value));
                        List<ApiBillOfMaterialsResponseModel> response = await this.BillOfMaterialsService.All(query.Limit, query.Offset);

                        return this.Ok(response);
                }

                [HttpGet]
                [Route("{id}")]
                [ReadOnly]
                [ProducesResponseType(typeof(ApiBillOfMaterialsResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> Get(int id)
                {
                        ApiBillOfMaterialsResponseModel response = await this.BillOfMaterialsService.Get(id);

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
                [ProducesResponseType(typeof(List<ApiBillOfMaterialsResponseModel>), 200)]
                [ProducesResponseType(typeof(void), 413)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> BulkInsert([FromBody] List<ApiBillOfMaterialsRequestModel> models)
                {
                        if (models.Count > this.BulkInsertLimit)
                        {
                                return this.StatusCode(StatusCodes.Status413PayloadTooLarge);
                        }

                        List<ApiBillOfMaterialsResponseModel> records = new List<ApiBillOfMaterialsResponseModel>();
                        foreach (var model in models)
                        {
                                CreateResponse<ApiBillOfMaterialsResponseModel> result = await this.BillOfMaterialsService.Create(model);

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
                [ProducesResponseType(typeof(ApiBillOfMaterialsResponseModel), 201)]
                [ProducesResponseType(typeof(CreateResponse<int>), 422)]
                public virtual async Task<IActionResult> Create([FromBody] ApiBillOfMaterialsRequestModel model)
                {
                        CreateResponse<ApiBillOfMaterialsResponseModel> result = await this.BillOfMaterialsService.Create(model);

                        if (result.Success)
                        {
                                return this.Created($"{this.Settings.ExternalBaseUrl}/api/BillOfMaterials/{result.Record.BillOfMaterialsID}", result.Record);
                        }
                        else
                        {
                                return this.StatusCode(StatusCodes.Status422UnprocessableEntity, result);
                        }
                }

                [HttpPatch]
                [Route("{id}")]
                [UnitOfWork]
                [ProducesResponseType(typeof(ApiBillOfMaterialsResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<ApiBillOfMaterialsRequestModel> patch)
                {
                        ApiBillOfMaterialsResponseModel record = await this.BillOfMaterialsService.Get(id);

                        if (record == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ApiBillOfMaterialsRequestModel model = await this.PatchModel(id, patch);

                                ActionResponse result = await this.BillOfMaterialsService.Update(id, model);

                                if (result.Success)
                                {
                                        ApiBillOfMaterialsResponseModel response = await this.BillOfMaterialsService.Get(id);

                                        return this.Ok(response);
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
                [ProducesResponseType(typeof(ApiBillOfMaterialsResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                [ProducesResponseType(typeof(ActionResponse), 422)]
                public virtual async Task<IActionResult> Update(int id, [FromBody] ApiBillOfMaterialsRequestModel model)
                {
                        ApiBillOfMaterialsRequestModel request = await this.PatchModel(id, this.CreatePatch(model));

                        if (request == null)
                        {
                                return this.StatusCode(StatusCodes.Status404NotFound);
                        }
                        else
                        {
                                ActionResponse result = await this.BillOfMaterialsService.Update(id, request);

                                if (result.Success)
                                {
                                        ApiBillOfMaterialsResponseModel response = await this.BillOfMaterialsService.Get(id);

                                        return this.Ok(response);
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
                        ActionResponse result = await this.BillOfMaterialsService.Delete(id);

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
                [ProducesResponseType(typeof(ApiBillOfMaterialsResponseModel), 200)]
                [ProducesResponseType(typeof(void), 404)]
                public async virtual Task<IActionResult> ByProductAssemblyIDComponentIDStartDate(int? productAssemblyID, int componentID, DateTime startDate)
                {
                        ApiBillOfMaterialsResponseModel response = await this.BillOfMaterialsService.ByProductAssemblyIDComponentIDStartDate(productAssemblyID, componentID, startDate);

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
                [ProducesResponseType(typeof(List<ApiBillOfMaterialsResponseModel>), 200)]
                public async virtual Task<IActionResult> ByUnitMeasureCode(string unitMeasureCode)
                {
                        List<ApiBillOfMaterialsResponseModel> response = await this.BillOfMaterialsService.ByUnitMeasureCode(unitMeasureCode);

                        return this.Ok(response);
                }

                private JsonPatchDocument<ApiBillOfMaterialsRequestModel> CreatePatch(ApiBillOfMaterialsRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiBillOfMaterialsRequestModel>();
                        patch.Replace(x => x.BOMLevel, model.BOMLevel);
                        patch.Replace(x => x.ComponentID, model.ComponentID);
                        patch.Replace(x => x.EndDate, model.EndDate);
                        patch.Replace(x => x.ModifiedDate, model.ModifiedDate);
                        patch.Replace(x => x.PerAssemblyQty, model.PerAssemblyQty);
                        patch.Replace(x => x.ProductAssemblyID, model.ProductAssemblyID);
                        patch.Replace(x => x.StartDate, model.StartDate);
                        patch.Replace(x => x.UnitMeasureCode, model.UnitMeasureCode);
                        return patch;
                }

                private async Task<ApiBillOfMaterialsRequestModel> PatchModel(int id, JsonPatchDocument<ApiBillOfMaterialsRequestModel> patch)
                {
                        var record = await this.BillOfMaterialsService.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                ApiBillOfMaterialsRequestModel request = this.BillOfMaterialsModelMapper.MapResponseToRequest(record);
                                patch.ApplyTo(request);
                                return request;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>5331740360dc02918e2f3110f060761f</Hash>
</Codenesium>*/