using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractCertificateService : AbstractService
        {
                private ICertificateRepository certificateRepository;

                private IApiCertificateRequestModelValidator certificateModelValidator;

                private IBOLCertificateMapper bolCertificateMapper;

                private IDALCertificateMapper dalCertificateMapper;

                private ILogger logger;

                public AbstractCertificateService(
                        ILogger logger,
                        ICertificateRepository certificateRepository,
                        IApiCertificateRequestModelValidator certificateModelValidator,
                        IBOLCertificateMapper bolCertificateMapper,
                        IDALCertificateMapper dalCertificateMapper)
                        : base()
                {
                        this.certificateRepository = certificateRepository;
                        this.certificateModelValidator = certificateModelValidator;
                        this.bolCertificateMapper = bolCertificateMapper;
                        this.dalCertificateMapper = dalCertificateMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiCertificateResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.certificateRepository.All(limit, offset);

                        return this.bolCertificateMapper.MapBOToModel(this.dalCertificateMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiCertificateResponseModel> Get(string id)
                {
                        var record = await this.certificateRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolCertificateMapper.MapBOToModel(this.dalCertificateMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiCertificateResponseModel>> Create(
                        ApiCertificateRequestModel model)
                {
                        CreateResponse<ApiCertificateResponseModel> response = new CreateResponse<ApiCertificateResponseModel>(await this.certificateModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolCertificateMapper.MapModelToBO(default(string), model);
                                var record = await this.certificateRepository.Create(this.dalCertificateMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolCertificateMapper.MapBOToModel(this.dalCertificateMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiCertificateRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.certificateModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolCertificateMapper.MapModelToBO(id, model);
                                await this.certificateRepository.Update(this.dalCertificateMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.certificateModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.certificateRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<List<ApiCertificateResponseModel>> GetCreated(DateTimeOffset created)
                {
                        List<Certificate> records = await this.certificateRepository.GetCreated(created);

                        return this.bolCertificateMapper.MapBOToModel(this.dalCertificateMapper.MapEFToBO(records));
                }

                public async Task<List<ApiCertificateResponseModel>> GetDataVersion(byte[] dataVersion)
                {
                        List<Certificate> records = await this.certificateRepository.GetDataVersion(dataVersion);

                        return this.bolCertificateMapper.MapBOToModel(this.dalCertificateMapper.MapEFToBO(records));
                }

                public async Task<List<ApiCertificateResponseModel>> GetNotAfter(DateTimeOffset notAfter)
                {
                        List<Certificate> records = await this.certificateRepository.GetNotAfter(notAfter);

                        return this.bolCertificateMapper.MapBOToModel(this.dalCertificateMapper.MapEFToBO(records));
                }

                public async Task<List<ApiCertificateResponseModel>> GetThumbprint(string thumbprint)
                {
                        List<Certificate> records = await this.certificateRepository.GetThumbprint(thumbprint);

                        return this.bolCertificateMapper.MapBOToModel(this.dalCertificateMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>b20d6fcb571991ba4cc94e955be559fe</Hash>
</Codenesium>*/