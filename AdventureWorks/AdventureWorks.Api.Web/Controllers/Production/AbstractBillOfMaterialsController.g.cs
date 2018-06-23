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

                protected int BulkInsertLimit { get; set; }

                protected int MaxLimit { get; set; }

                protected int DefaultLimit { get; set; }

                public AbstractBillOfMaterialsController(
                        ApiSettings settings,
                        ILogger<AbstractBillOfMaterialsController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBillOfMaterialsService billOfMaterialsService
                        )
                        : base(settings, logger, transactionCoordinator)
                {
                        this.BillOfMaterialsService = billOfMaterialsService;
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
                                ApiBillOfMaterialsRequestModel model = new ApiBillOfMaterialsRequestModel();
                                model.SetProperties(model.BOMLevel,
                                                    model.ComponentID,
                                                    model.EndDate,
                                                    model.ModifiedDate,
                                                    model.PerAssemblyQty,
                                                    model.ProductAssemblyID,
                                                    model.StartDate,
                                                    model.UnitMeasureCode);
                                patch.ApplyTo(model);
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
                public async virtual Task<IActionResult> ByProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID, int componentID, DateTime startDate)
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
        }
}

/*<Codenesium>
    <Hash>26e2f7d38b79f6aa31084a2b03f8d704</Hash>
</Codenesium>*/