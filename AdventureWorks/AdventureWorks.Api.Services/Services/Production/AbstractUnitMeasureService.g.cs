using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractUnitMeasureService : AbstractService
        {
                private IUnitMeasureRepository unitMeasureRepository;

                private IApiUnitMeasureRequestModelValidator unitMeasureModelValidator;

                private IBOLUnitMeasureMapper bolUnitMeasureMapper;

                private IDALUnitMeasureMapper dalUnitMeasureMapper;

                private IBOLBillOfMaterialMapper bolBillOfMaterialMapper;

                private IDALBillOfMaterialMapper dalBillOfMaterialMapper;
                private IBOLProductMapper bolProductMapper;

                private IDALProductMapper dalProductMapper;

                private ILogger logger;

                public AbstractUnitMeasureService(
                        ILogger logger,
                        IUnitMeasureRepository unitMeasureRepository,
                        IApiUnitMeasureRequestModelValidator unitMeasureModelValidator,
                        IBOLUnitMeasureMapper bolUnitMeasureMapper,
                        IDALUnitMeasureMapper dalUnitMeasureMapper,
                        IBOLBillOfMaterialMapper bolBillOfMaterialMapper,
                        IDALBillOfMaterialMapper dalBillOfMaterialMapper,
                        IBOLProductMapper bolProductMapper,
                        IDALProductMapper dalProductMapper)
                        : base()
                {
                        this.unitMeasureRepository = unitMeasureRepository;
                        this.unitMeasureModelValidator = unitMeasureModelValidator;
                        this.bolUnitMeasureMapper = bolUnitMeasureMapper;
                        this.dalUnitMeasureMapper = dalUnitMeasureMapper;
                        this.bolBillOfMaterialMapper = bolBillOfMaterialMapper;
                        this.dalBillOfMaterialMapper = dalBillOfMaterialMapper;
                        this.bolProductMapper = bolProductMapper;
                        this.dalProductMapper = dalProductMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiUnitMeasureResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.unitMeasureRepository.All(limit, offset);

                        return this.bolUnitMeasureMapper.MapBOToModel(this.dalUnitMeasureMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiUnitMeasureResponseModel> Get(string unitMeasureCode)
                {
                        var record = await this.unitMeasureRepository.Get(unitMeasureCode);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolUnitMeasureMapper.MapBOToModel(this.dalUnitMeasureMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiUnitMeasureResponseModel>> Create(
                        ApiUnitMeasureRequestModel model)
                {
                        CreateResponse<ApiUnitMeasureResponseModel> response = new CreateResponse<ApiUnitMeasureResponseModel>(await this.unitMeasureModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolUnitMeasureMapper.MapModelToBO(default(string), model);
                                var record = await this.unitMeasureRepository.Create(this.dalUnitMeasureMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolUnitMeasureMapper.MapBOToModel(this.dalUnitMeasureMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<UpdateResponse<ApiUnitMeasureResponseModel>> Update(
                        string unitMeasureCode,
                        ApiUnitMeasureRequestModel model)
                {
                        var validationResult = await this.unitMeasureModelValidator.ValidateUpdateAsync(unitMeasureCode, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolUnitMeasureMapper.MapModelToBO(unitMeasureCode, model);
                                await this.unitMeasureRepository.Update(this.dalUnitMeasureMapper.MapBOToEF(bo));

                                var record = await this.unitMeasureRepository.Get(unitMeasureCode);

                                return new UpdateResponse<ApiUnitMeasureResponseModel>(this.bolUnitMeasureMapper.MapBOToModel(this.dalUnitMeasureMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiUnitMeasureResponseModel>(validationResult);
                        }
                }

                public virtual async Task<ActionResponse> Delete(
                        string unitMeasureCode)
                {
                        ActionResponse response = new ActionResponse(await this.unitMeasureModelValidator.ValidateDeleteAsync(unitMeasureCode));
                        if (response.Success)
                        {
                                await this.unitMeasureRepository.Delete(unitMeasureCode);
                        }

                        return response;
                }

                public async Task<ApiUnitMeasureResponseModel> ByName(string name)
                {
                        UnitMeasure record = await this.unitMeasureRepository.ByName(name);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolUnitMeasureMapper.MapBOToModel(this.dalUnitMeasureMapper.MapEFToBO(record));
                        }
                }

                public async virtual Task<List<ApiBillOfMaterialResponseModel>> BillOfMaterials(string unitMeasureCode, int limit = int.MaxValue, int offset = 0)
                {
                        List<BillOfMaterial> records = await this.unitMeasureRepository.BillOfMaterials(unitMeasureCode, limit, offset);

                        return this.bolBillOfMaterialMapper.MapBOToModel(this.dalBillOfMaterialMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiProductResponseModel>> Products(string sizeUnitMeasureCode, int limit = int.MaxValue, int offset = 0)
                {
                        List<Product> records = await this.unitMeasureRepository.Products(sizeUnitMeasureCode, limit, offset);

                        return this.bolProductMapper.MapBOToModel(this.dalProductMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>f1ff830e3dea3cc63a74135b9abbd097</Hash>
</Codenesium>*/