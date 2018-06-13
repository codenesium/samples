using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;

namespace ESPIOTNS.Api.Services
{
        public abstract class AbstractDeviceService: AbstractService
        {
                private IDeviceRepository deviceRepository;

                private IApiDeviceRequestModelValidator deviceModelValidator;

                private IBOLDeviceMapper bolDeviceMapper;

                private IDALDeviceMapper dalDeviceMapper;

                private IBOLDeviceActionMapper bolDeviceActionMapper;

                private IDALDeviceActionMapper dalDeviceActionMapper;

                private ILogger logger;

                public AbstractDeviceService(
                        ILogger logger,
                        IDeviceRepository deviceRepository,
                        IApiDeviceRequestModelValidator deviceModelValidator,
                        IBOLDeviceMapper bolDeviceMapper,
                        IDALDeviceMapper dalDeviceMapper

                        ,
                        IBOLDeviceActionMapper bolDeviceActionMapper,
                        IDALDeviceActionMapper dalDeviceActionMapper

                        )
                        : base()

                {
                        this.deviceRepository = deviceRepository;
                        this.deviceModelValidator = deviceModelValidator;
                        this.bolDeviceMapper = bolDeviceMapper;
                        this.dalDeviceMapper = dalDeviceMapper;
                        this.bolDeviceActionMapper = bolDeviceActionMapper;
                        this.dalDeviceActionMapper = dalDeviceActionMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiDeviceResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.deviceRepository.All(limit, offset, orderClause);

                        return this.bolDeviceMapper.MapBOToModel(this.dalDeviceMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiDeviceResponseModel> Get(int id)
                {
                        var record = await this.deviceRepository.Get(id);

                        return this.bolDeviceMapper.MapBOToModel(this.dalDeviceMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiDeviceResponseModel>> Create(
                        ApiDeviceRequestModel model)
                {
                        CreateResponse<ApiDeviceResponseModel> response = new CreateResponse<ApiDeviceResponseModel>(await this.deviceModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolDeviceMapper.MapModelToBO(default (int), model);
                                var record = await this.deviceRepository.Create(this.dalDeviceMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolDeviceMapper.MapBOToModel(this.dalDeviceMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiDeviceRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.deviceModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolDeviceMapper.MapModelToBO(id, model);
                                await this.deviceRepository.Update(this.dalDeviceMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.deviceModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.deviceRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiDeviceResponseModel> ByPublicId(Guid publicId)
                {
                        Device record = await this.deviceRepository.ByPublicId(publicId);

                        return this.bolDeviceMapper.MapBOToModel(this.dalDeviceMapper.MapEFToBO(record));
                }

                public async virtual Task<List<ApiDeviceActionResponseModel>> DeviceActions(int deviceId, int limit = int.MaxValue, int offset = 0)
                {
                        List<DeviceAction> records = await this.deviceRepository.DeviceActions(deviceId, limit, offset);

                        return this.bolDeviceActionMapper.MapBOToModel(this.dalDeviceActionMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>ce5b8c6c08b20ee8f16f21e69d83d88d</Hash>
</Codenesium>*/