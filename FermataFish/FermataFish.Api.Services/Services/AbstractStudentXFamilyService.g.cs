using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractStudentXFamilyService : AbstractService
        {
                private IStudentXFamilyRepository studentXFamilyRepository;

                private IApiStudentXFamilyRequestModelValidator studentXFamilyModelValidator;

                private IBOLStudentXFamilyMapper bolStudentXFamilyMapper;

                private IDALStudentXFamilyMapper dalStudentXFamilyMapper;

                private ILogger logger;

                public AbstractStudentXFamilyService(
                        ILogger logger,
                        IStudentXFamilyRepository studentXFamilyRepository,
                        IApiStudentXFamilyRequestModelValidator studentXFamilyModelValidator,
                        IBOLStudentXFamilyMapper bolStudentXFamilyMapper,
                        IDALStudentXFamilyMapper dalStudentXFamilyMapper)
                        : base()
                {
                        this.studentXFamilyRepository = studentXFamilyRepository;
                        this.studentXFamilyModelValidator = studentXFamilyModelValidator;
                        this.bolStudentXFamilyMapper = bolStudentXFamilyMapper;
                        this.dalStudentXFamilyMapper = dalStudentXFamilyMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiStudentXFamilyResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.studentXFamilyRepository.All(limit, offset);

                        return this.bolStudentXFamilyMapper.MapBOToModel(this.dalStudentXFamilyMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiStudentXFamilyResponseModel> Get(int id)
                {
                        var record = await this.studentXFamilyRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolStudentXFamilyMapper.MapBOToModel(this.dalStudentXFamilyMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiStudentXFamilyResponseModel>> Create(
                        ApiStudentXFamilyRequestModel model)
                {
                        CreateResponse<ApiStudentXFamilyResponseModel> response = new CreateResponse<ApiStudentXFamilyResponseModel>(await this.studentXFamilyModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolStudentXFamilyMapper.MapModelToBO(default(int), model);
                                var record = await this.studentXFamilyRepository.Create(this.dalStudentXFamilyMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolStudentXFamilyMapper.MapBOToModel(this.dalStudentXFamilyMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiStudentXFamilyRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.studentXFamilyModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolStudentXFamilyMapper.MapModelToBO(id, model);
                                await this.studentXFamilyRepository.Update(this.dalStudentXFamilyMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.studentXFamilyModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.studentXFamilyRepository.Delete(id);
                        }

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>74ba4a10bb7ac8c8f01639b965d574a3</Hash>
</Codenesium>*/