using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractLibraryVariableSetService: AbstractService
        {
                private ILibraryVariableSetRepository libraryVariableSetRepository;

                private IApiLibraryVariableSetRequestModelValidator libraryVariableSetModelValidator;

                private IBOLLibraryVariableSetMapper bolLibraryVariableSetMapper;

                private IDALLibraryVariableSetMapper dalLibraryVariableSetMapper;

                private ILogger logger;

                public AbstractLibraryVariableSetService(
                        ILogger logger,
                        ILibraryVariableSetRepository libraryVariableSetRepository,
                        IApiLibraryVariableSetRequestModelValidator libraryVariableSetModelValidator,
                        IBOLLibraryVariableSetMapper bollibraryVariableSetMapper,
                        IDALLibraryVariableSetMapper dallibraryVariableSetMapper)
                        : base()

                {
                        this.libraryVariableSetRepository = libraryVariableSetRepository;
                        this.libraryVariableSetModelValidator = libraryVariableSetModelValidator;
                        this.bolLibraryVariableSetMapper = bollibraryVariableSetMapper;
                        this.dalLibraryVariableSetMapper = dallibraryVariableSetMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiLibraryVariableSetResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.libraryVariableSetRepository.All(skip, take, orderClause);

                        return this.bolLibraryVariableSetMapper.MapBOToModel(this.dalLibraryVariableSetMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiLibraryVariableSetResponseModel> Get(string id)
                {
                        var record = await this.libraryVariableSetRepository.Get(id);

                        return this.bolLibraryVariableSetMapper.MapBOToModel(this.dalLibraryVariableSetMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiLibraryVariableSetResponseModel>> Create(
                        ApiLibraryVariableSetRequestModel model)
                {
                        CreateResponse<ApiLibraryVariableSetResponseModel> response = new CreateResponse<ApiLibraryVariableSetResponseModel>(await this.libraryVariableSetModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolLibraryVariableSetMapper.MapModelToBO(default (string), model);
                                var record = await this.libraryVariableSetRepository.Create(this.dalLibraryVariableSetMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolLibraryVariableSetMapper.MapBOToModel(this.dalLibraryVariableSetMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        string id,
                        ApiLibraryVariableSetRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.libraryVariableSetModelValidator.ValidateUpdateAsync(id, model));

                        if (response.Success)
                        {
                                var bo = this.bolLibraryVariableSetMapper.MapModelToBO(id, model);
                                await this.libraryVariableSetRepository.Update(this.dalLibraryVariableSetMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        string id)
                {
                        ActionResponse response = new ActionResponse(await this.libraryVariableSetModelValidator.ValidateDeleteAsync(id));

                        if (response.Success)
                        {
                                await this.libraryVariableSetRepository.Delete(id);
                        }

                        return response;
                }

                public async Task<ApiLibraryVariableSetResponseModel> GetName(string name)
                {
                        LibraryVariableSet record = await this.libraryVariableSetRepository.GetName(name);

                        return this.bolLibraryVariableSetMapper.MapBOToModel(this.dalLibraryVariableSetMapper.MapEFToBO(record));
                }
        }
}

/*<Codenesium>
    <Hash>0378df938eb1f1852e8a48e4646aac4a</Hash>
</Codenesium>*/