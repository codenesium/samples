using Codenesium.DataConversionExtensions.AspNetCore;
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
        public abstract class AbstractFamilyService : AbstractService
        {
                private IFamilyRepository familyRepository;

                private IApiFamilyRequestModelValidator familyModelValidator;

                private IBOLFamilyMapper bolFamilyMapper;

                private IDALFamilyMapper dalFamilyMapper;

                private IBOLStudentMapper bolStudentMapper;

                private IDALStudentMapper dalStudentMapper;
                private IBOLStudentXFamilyMapper bolStudentXFamilyMapper;

                private IDALStudentXFamilyMapper dalStudentXFamilyMapper;

                private ILogger logger;

                public AbstractFamilyService(
                        ILogger logger,
                        IFamilyRepository familyRepository,
                        IApiFamilyRequestModelValidator familyModelValidator,
                        IBOLFamilyMapper bolFamilyMapper,
                        IDALFamilyMapper dalFamilyMapper,
                        IBOLStudentMapper bolStudentMapper,
                        IDALStudentMapper dalStudentMapper,
                        IBOLStudentXFamilyMapper bolStudentXFamilyMapper,
                        IDALStudentXFamilyMapper dalStudentXFamilyMapper)
                        : base()
                {
                        this.familyRepository = familyRepository;
                        this.familyModelValidator = familyModelValidator;
                        this.bolFamilyMapper = bolFamilyMapper;
                        this.dalFamilyMapper = dalFamilyMapper;
                        this.bolStudentMapper = bolStudentMapper;
                        this.dalStudentMapper = dalStudentMapper;
                        this.bolStudentXFamilyMapper = bolStudentXFamilyMapper;
                        this.dalStudentXFamilyMapper = dalStudentXFamilyMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiFamilyResponseModel>> All(int limit = 0, int offset = int.MaxValue)
                {
                        var records = await this.familyRepository.All(limit, offset);

                        return this.bolFamilyMapper.MapBOToModel(this.dalFamilyMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiFamilyResponseModel> Get(int id)
                {
                        var record = await this.familyRepository.Get(id);

                        if (record == null)
                        {
                                return null;
                        }
                        else
                        {
                                return this.bolFamilyMapper.MapBOToModel(this.dalFamilyMapper.MapEFToBO(record));
                        }
                }

                public virtual async Task<CreateResponse<ApiFamilyResponseModel>> Create(
                        ApiFamilyRequestModel model)
                {
                        CreateResponse<ApiFamilyResponseModel> response = new CreateResponse<ApiFamilyResponseModel>(await this.familyModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolFamilyMapper.MapModelToBO(default(int), model);
                                var record = await this.familyRepository.Create(this.dalFamilyMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolFamilyMapper.MapBOToModel(this.dalFamilyMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int id,
                        ApiFamilyRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.familyModelValidator.ValidateUpdateAsync(id, model));
                        if (response.Success)
                        {
                                var bo = this.bolFamilyMapper.MapModelToBO(id, model);
                                await this.familyRepository.Update(this.dalFamilyMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int id)
                {
                        ActionResponse response = new ActionResponse(await this.familyModelValidator.ValidateDeleteAsync(id));
                        if (response.Success)
                        {
                                await this.familyRepository.Delete(id);
                        }

                        return response;
                }

                public async virtual Task<List<ApiStudentResponseModel>> Students(int familyId, int limit = int.MaxValue, int offset = 0)
                {
                        List<Student> records = await this.familyRepository.Students(familyId, limit, offset);

                        return this.bolStudentMapper.MapBOToModel(this.dalStudentMapper.MapEFToBO(records));
                }

                public async virtual Task<List<ApiStudentXFamilyResponseModel>> StudentXFamilies(int familyId, int limit = int.MaxValue, int offset = 0)
                {
                        List<StudentXFamily> records = await this.familyRepository.StudentXFamilies(familyId, limit, offset);

                        return this.bolStudentXFamilyMapper.MapBOToModel(this.dalStudentXFamilyMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>a8eecede423f1ab1be11c2b353dbeaed</Hash>
</Codenesium>*/