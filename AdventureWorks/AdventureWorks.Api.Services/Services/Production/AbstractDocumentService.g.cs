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
        public abstract class AbstractDocumentService: AbstractService
        {
                private IDocumentRepository documentRepository;

                private IApiDocumentRequestModelValidator documentModelValidator;

                private IBOLDocumentMapper bolDocumentMapper;

                private IDALDocumentMapper dalDocumentMapper;

                private IBOLProductDocumentMapper bolProductDocumentMapper;

                private IDALProductDocumentMapper dalProductDocumentMapper;

                private ILogger logger;

                public AbstractDocumentService(
                        ILogger logger,
                        IDocumentRepository documentRepository,
                        IApiDocumentRequestModelValidator documentModelValidator,
                        IBOLDocumentMapper bolDocumentMapper,
                        IDALDocumentMapper dalDocumentMapper

                        ,
                        IBOLProductDocumentMapper bolProductDocumentMapper,
                        IDALProductDocumentMapper dalProductDocumentMapper

                        )
                        : base()

                {
                        this.documentRepository = documentRepository;
                        this.documentModelValidator = documentModelValidator;
                        this.bolDocumentMapper = bolDocumentMapper;
                        this.dalDocumentMapper = dalDocumentMapper;
                        this.bolProductDocumentMapper = bolProductDocumentMapper;
                        this.dalProductDocumentMapper = dalProductDocumentMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiDocumentResponseModel>> All(int limit = 0, int offset = int.MaxValue, string orderClause = "")
                {
                        var records = await this.documentRepository.All(limit, offset, orderClause);

                        return this.bolDocumentMapper.MapBOToModel(this.dalDocumentMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiDocumentResponseModel> Get(Guid documentNode)
                {
                        var record = await this.documentRepository.Get(documentNode);

                        return this.bolDocumentMapper.MapBOToModel(this.dalDocumentMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiDocumentResponseModel>> Create(
                        ApiDocumentRequestModel model)
                {
                        CreateResponse<ApiDocumentResponseModel> response = new CreateResponse<ApiDocumentResponseModel>(await this.documentModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolDocumentMapper.MapModelToBO(default (Guid), model);
                                var record = await this.documentRepository.Create(this.dalDocumentMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolDocumentMapper.MapBOToModel(this.dalDocumentMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        Guid documentNode,
                        ApiDocumentRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.documentModelValidator.ValidateUpdateAsync(documentNode, model));

                        if (response.Success)
                        {
                                var bo = this.bolDocumentMapper.MapModelToBO(documentNode, model);
                                await this.documentRepository.Update(this.dalDocumentMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        Guid documentNode)
                {
                        ActionResponse response = new ActionResponse(await this.documentModelValidator.ValidateDeleteAsync(documentNode));

                        if (response.Success)
                        {
                                await this.documentRepository.Delete(documentNode);
                        }

                        return response;
                }

                public async Task<ApiDocumentResponseModel> GetDocumentLevelDocumentNode(Nullable<short> documentLevel, Guid documentNode)
                {
                        Document record = await this.documentRepository.GetDocumentLevelDocumentNode(documentLevel, documentNode);

                        return this.bolDocumentMapper.MapBOToModel(this.dalDocumentMapper.MapEFToBO(record));
                }
                public async Task<List<ApiDocumentResponseModel>> GetFileNameRevision(string fileName, string revision)
                {
                        List<Document> records = await this.documentRepository.GetFileNameRevision(fileName, revision);

                        return this.bolDocumentMapper.MapBOToModel(this.dalDocumentMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiProductDocumentResponseModel>> ProductDocuments(Guid documentNode, int limit = int.MaxValue, int offset = 0)
                {
                        List<ProductDocument> records = await this.documentRepository.ProductDocuments(documentNode, limit, offset);

                        return this.bolProductDocumentMapper.MapBOToModel(this.dalProductDocumentMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>9cddc25ea293b4843428ca27f71b6410</Hash>
</Codenesium>*/