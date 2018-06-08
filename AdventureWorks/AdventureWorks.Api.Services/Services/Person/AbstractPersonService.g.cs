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
        public abstract class AbstractPersonService: AbstractService
        {
                private IPersonRepository personRepository;

                private IApiPersonRequestModelValidator personModelValidator;

                private IBOLPersonMapper bolPersonMapper;

                private IDALPersonMapper dalPersonMapper;

                private ILogger logger;

                public AbstractPersonService(
                        ILogger logger,
                        IPersonRepository personRepository,
                        IApiPersonRequestModelValidator personModelValidator,
                        IBOLPersonMapper bolpersonMapper,
                        IDALPersonMapper dalpersonMapper)
                        : base()

                {
                        this.personRepository = personRepository;
                        this.personModelValidator = personModelValidator;
                        this.bolPersonMapper = bolpersonMapper;
                        this.dalPersonMapper = dalpersonMapper;
                        this.logger = logger;
                }

                public virtual async Task<List<ApiPersonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        var records = await this.personRepository.All(skip, take, orderClause);

                        return this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(records));
                }

                public virtual async Task<ApiPersonResponseModel> Get(int businessEntityID)
                {
                        var record = await this.personRepository.Get(businessEntityID);

                        return this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(record));
                }

                public virtual async Task<CreateResponse<ApiPersonResponseModel>> Create(
                        ApiPersonRequestModel model)
                {
                        CreateResponse<ApiPersonResponseModel> response = new CreateResponse<ApiPersonResponseModel>(await this.personModelValidator.ValidateCreateAsync(model));
                        if (response.Success)
                        {
                                var bo = this.bolPersonMapper.MapModelToBO(default (int), model);
                                var record = await this.personRepository.Create(this.dalPersonMapper.MapBOToEF(bo));

                                response.SetRecord(this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(record)));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Update(
                        int businessEntityID,
                        ApiPersonRequestModel model)
                {
                        ActionResponse response = new ActionResponse(await this.personModelValidator.ValidateUpdateAsync(businessEntityID, model));

                        if (response.Success)
                        {
                                var bo = this.bolPersonMapper.MapModelToBO(businessEntityID, model);
                                await this.personRepository.Update(this.dalPersonMapper.MapBOToEF(bo));
                        }

                        return response;
                }

                public virtual async Task<ActionResponse> Delete(
                        int businessEntityID)
                {
                        ActionResponse response = new ActionResponse(await this.personModelValidator.ValidateDeleteAsync(businessEntityID));

                        if (response.Success)
                        {
                                await this.personRepository.Delete(businessEntityID);
                        }

                        return response;
                }

                public async Task<List<ApiPersonResponseModel>> GetLastNameFirstNameMiddleName(string lastName, string firstName, string middleName)
                {
                        List<Person> records = await this.personRepository.GetLastNameFirstNameMiddleName(lastName, firstName, middleName);

                        return this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(records));
                }
                public async Task<List<ApiPersonResponseModel>> GetAdditionalContactInfo(string additionalContactInfo)
                {
                        List<Person> records = await this.personRepository.GetAdditionalContactInfo(additionalContactInfo);

                        return this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(records));
                }
                public async Task<List<ApiPersonResponseModel>> GetDemographics(string demographics)
                {
                        List<Person> records = await this.personRepository.GetDemographics(demographics);

                        return this.bolPersonMapper.MapBOToModel(this.dalPersonMapper.MapEFToBO(records));
                }
        }
}

/*<Codenesium>
    <Hash>d17043d9458f4d7741d524ef26a3ffd4</Hash>
</Codenesium>*/