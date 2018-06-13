using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBillOfMaterialsService: AbstractService
        {
                private IBillOfMaterialsRepository billOfMaterialsRepository;

                private IApiBillOfMaterialsRequestModelValidator billOfMaterialsModelValidator;

                private IBOLBillOfMaterialsMapper bolBillOfMaterialsMapper;

                private IDALBillOfMaterialsMapper dalBillOfMaterialsMapper;

                private ILogger logger;

                public AbstractBillOfMaterialsService(
                        ILogger logger,
                        IBillOfMaterialsRepository billOfMaterialsRepository,
                        IApiBillOfMaterialsRequestModelValidator billOfMaterialsModelValidator,
                        IBOLBillOfMaterialsMapper bolBillOfMaterialsMapper,
                        IDALBillOfMaterialsMapper dalBillOfMaterialsMapper

                        )
                        : base()

                {
                        this.billOfMaterialsRepository = billOfMaterialsRepository;
                        this.billOfMaterialsModelValidator = billOfMaterialsModelValidator;
                        this.bolBillOfMaterialsMapper = bolBillOfMaterialsMapper;
                        this.dalBillOfMaterialsMapper = dalBillOfMaterialsMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiBillOfMaterialsResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.billOfMaterialsRepository.All(limit, offset, orderClause);

                        return this.bolBillOfMaterialsMapper.MapBOToModel(this.dalBillOfMaterialsMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiBillOfMaterialsResponseModel> Get(int billOfMaterialsID)
                {
                        var record = await this.billOfMaterialsRepository.Get(billOfMaterialsID);

                        return this.bolBillOfMaterialsMapper.MapBOToModel(this.dalBillOfMaterialsMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiBillOfMaterialsResponseModel>> Create(
                        ApiBillOfMaterialsRequestModel model)
                {
                        CreateResponse<ApiBillOfMaterialsResponseModel> response = new CreateResponse<ApiBillOfMaterialsResponseModel>(await this.billOfMaterialsModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolBillOfMaterialsMapper.MapModelToBO(default (int), model);
                                var record = await this.billOfMaterialsRepository.Create(this.dalBillOfMaterialsMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolBillOfMaterialsMapper.MapBOToModel(this.dalBillOfMaterialsMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int billOfMaterialsID,
                        ApiBillOfMaterialsRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.billOfMaterialsModelValidator.ValidateUpdateAsync(billOfMaterialsID, model));

                        if (response.Success)
                        {
                                var bo = this.bolBillOfMaterialsMapper.MapModelToBO(billOfMaterialsID, model);
                                await this.billOfMaterialsRepository.Update(this.dalBillOfMaterialsMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int billOfMaterialsID)
                {
                        ActionResponse response = new ActionResponse(await this.billOfMaterialsModelValidator.ValidateDeleteAsync(billOfMaterialsID));

                        if (response.Success)
                        {
                                await this.billOfMaterialsRepository.Delete(billOfMaterialsID);
                        }

                        return response;
                }

                public async Task<ApiBillOfMaterialsResponseModel> GetProductAssemblyIDComponentIDStartDate(Nullable<int> productAssemblyID, int componentID, DateTime startDate)
                {
                        BillOfMaterials record = await this.billOfMaterialsRepository.GetProductAssemblyIDComponentIDStartDate(productAssemblyID, componentID, startDate);

                        return this.bolBillOfMaterialsMapper.MapBOToModel(this.dalBillOfMaterialsMapper.MapEFToBO(record));
                }
                public async Task<List<ApiBillOfMaterialsResponseModel>> GetUnitMeasureCode(string unitMeasureCode)
                {
                        List<BillOfMaterials> records = await this.billOfMaterialsRepository.GetUnitMeasureCode(unitMeasureCode);

                        return this.bolBillOfMaterialsMapper.MapBOToModel(this.dalBillOfMaterialsMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>3f3d63b235be59b99a37fcf96a381f22</Hash>
</Codenesium>*/