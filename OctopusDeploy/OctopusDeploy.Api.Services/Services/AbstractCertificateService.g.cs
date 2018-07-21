using Codenesium.DataConversionExtensions;
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

                public virtual async Task<UpdateResponse<ApiCertificateResponseModel>> Update(
                        string id,
                        ApiCertificateRequestModel model)
                {
                        var validationResult = await this.certificateModelValidator.ValidateUpdateAsync(id, model);

                        if (validationResult.IsValid)
                        {
                                var bo = this.bolCertificateMapper.MapModelToBO(id, model);
                                await this.certificateRepository.Update(this.dalCertificateMapper.MapBOToEF(bo));

                                var record = await this.certificateRepository.Get(id);

                                return new UpdateResponse<ApiCertificateResponseModel>(this.bolCertificateMapper.MapBOToModel(this.dalCertificateMapper.MapEFToBO(record)));
                        }
                        else
                        {
                                return new UpdateResponse<ApiCertificateResponseModel>(validationResult);
                        }
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

                public async Task<List<ApiCertificateResponseModel>> ByCreated(DateTimeOffset created)
                {
                        List<Certificate> records = await this.certificateRepository.ByCreated(created);

                        return this.bolCertificateMapper.MapBOToModel(this.dalCertificateMapper.MapEFToBO(records));
                }

                public async Task<List<ApiCertificateResponseModel>> ByDataVersion(byte[] dataVersion)
                {
                        List<Certificate> records = await this.certificateRepository.ByDataVersion(dataVersion);

                        return this.bolCertificateMapper.MapBOToModel(this.dalCertificateMapper.MapEFToBO(records));
                }

                public async Task<List<ApiCertificateResponseModel>> ByNotAfter(DateTimeOffset notAfter)
                {
                        List<Certificate> records = await this.certificateRepository.ByNotAfter(notAfter);

                        return this.bolCertificateMapper.MapBOToModel(this.dalCertificateMapper.MapEFToBO(records));
                }

                public async Task<List<ApiCertificateResponseModel>> ByThumbprint(string thumbprint)
                {
                        List<Certificate> records = await this.certificateRepository.ByThumbprint(thumbprint);

                        return this.bolCertificateMapper.MapBOToModel(this.dalCertificateMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>0496c2924fa5b5137878bbae9fdb76cb</Hash>
</Codenesium>*/