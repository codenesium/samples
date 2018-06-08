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
        public abstract class AbstractDepartmentService: AbstractService
        {
                private IDepartmentRepository departmentRepository;

                private IApiDepartmentRequestModelValidator departmentModelValidator;

                private IBOLDepartmentMapper bolDepartmentMapper;

                private IDALDepartmentMapper dalDepartmentMapper;

                private ILogger logger;

                public AbstractDepartmentService(
                        ILogger logger,
                        IDepartmentRepository departmentRepository,
                        IApiDepartmentRequestModelValidator departmentModelValidator,
                        IBOLDepartmentMapper boldepartmentMapper,
                        IDALDepartmentMapper daldepartmentMapper)
                        : base()

                {
                        this.departmentRepository = departmentRepository;
                        this.departmentModelValidator = departmentModelValidator;
                        this.bolDepartmentMapper = boldepartmentMapper;
                        this.dalDepartmentMapper = daldepartmentMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiDepartmentResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.departmentRepository.All(skip, take, orderClause);

                        return this.bolDepartmentMapper.MapBOToModel(this.dalDepartmentMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiDepartmentResponseModel> Get(short departmentID)
                {
                        var record = await this.departmentRepository.Get(departmentID);

                        return this.bolDepartmentMapper.MapBOToModel(this.dalDepartmentMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiDepartmentResponseModel>> Create(
                        ApiDepartmentRequestModel model)
                {
                        CreateResponse<ApiDepartmentResponseModel> response = new CreateResponse<ApiDepartmentResponseModel>(await this.departmentModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolDepartmentMapper.MapModelToBO(default (short), model);
                                var record = await this.departmentRepository.Create(this.dalDepartmentMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolDepartmentMapper.MapBOToModel(this.dalDepartmentMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        short departmentID,
                        ApiDepartmentRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.departmentModelValidator.ValidateUpdateAsync(departmentID, model));

                        if (response.Success)
                        {
                                var bo = this.bolDepartmentMapper.MapModelToBO(departmentID, model);
                                await this.departmentRepository.Update(this.dalDepartmentMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        short departmentID)
                {
                        ActionResponse response = new ActionResponse(await this.departmentModelValidator.ValidateDeleteAsync(departmentID));

                        if (response.Success)
                        {
                                await this.departmentRepository.Delete(departmentID);
                        }

                        return response;
                }

                public async Task<ApiDepartmentResponseModel> GetName(string name)
                {
                        Department record = await this.departmentRepository.GetName(name);

                        return this.bolDepartmentMapper.MapBOToModel(this.dalDepartmentMapper.MapEFToBO(record));
                }
        }
}

/*<Codenesium>
    <Hash>08abbfde89781aa5606a81e57f4ce4e0</Hash>
</Codenesium>*/