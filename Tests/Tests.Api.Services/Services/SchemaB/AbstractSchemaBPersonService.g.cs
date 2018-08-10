using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractSchemaBPersonService : AbstractService
	{
		protected ISchemaBPersonRepository SchemaBPersonRepository { get; private set; }

		protected IApiSchemaBPersonRequestModelValidator SchemaBPersonModelValidator { get; private set; }

		protected IBOLSchemaBPersonMapper BolSchemaBPersonMapper { get; private set; }

		protected IDALSchemaBPersonMapper DalSchemaBPersonMapper { get; private set; }

		protected IBOLPersonRefMapper BolPersonRefMapper { get; private set; }

		protected IDALPersonRefMapper DalPersonRefMapper { get; private set; }

		private ILogger logger;

		public AbstractSchemaBPersonService(
			ILogger logger,
			ISchemaBPersonRepository schemaBPersonRepository,
			IApiSchemaBPersonRequestModelValidator schemaBPersonModelValidator,
			IBOLSchemaBPersonMapper bolSchemaBPersonMapper,
			IDALSchemaBPersonMapper dalSchemaBPersonMapper,
			IBOLPersonRefMapper bolPersonRefMapper,
			IDALPersonRefMapper dalPersonRefMapper)
			: base()
		{
			this.SchemaBPersonRepository = schemaBPersonRepository;
			this.SchemaBPersonModelValidator = schemaBPersonModelValidator;
			this.BolSchemaBPersonMapper = bolSchemaBPersonMapper;
			this.DalSchemaBPersonMapper = dalSchemaBPersonMapper;
			this.BolPersonRefMapper = bolPersonRefMapper;
			this.DalPersonRefMapper = dalPersonRefMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSchemaBPersonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SchemaBPersonRepository.All(limit, offset);

			return this.BolSchemaBPersonMapper.MapBOToModel(this.DalSchemaBPersonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSchemaBPersonResponseModel> Get(int id)
		{
			var record = await this.SchemaBPersonRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSchemaBPersonMapper.MapBOToModel(this.DalSchemaBPersonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSchemaBPersonResponseModel>> Create(
			ApiSchemaBPersonRequestModel model)
		{
			CreateResponse<ApiSchemaBPersonResponseModel> response = new CreateResponse<ApiSchemaBPersonResponseModel>(await this.SchemaBPersonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSchemaBPersonMapper.MapModelToBO(default(int), model);
				var record = await this.SchemaBPersonRepository.Create(this.DalSchemaBPersonMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSchemaBPersonMapper.MapBOToModel(this.DalSchemaBPersonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSchemaBPersonResponseModel>> Update(
			int id,
			ApiSchemaBPersonRequestModel model)
		{
			var validationResult = await this.SchemaBPersonModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSchemaBPersonMapper.MapModelToBO(id, model);
				await this.SchemaBPersonRepository.Update(this.DalSchemaBPersonMapper.MapBOToEF(bo));

				var record = await this.SchemaBPersonRepository.Get(id);

				return new UpdateResponse<ApiSchemaBPersonResponseModel>(this.BolSchemaBPersonMapper.MapBOToModel(this.DalSchemaBPersonMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSchemaBPersonResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.SchemaBPersonModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.SchemaBPersonRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiPersonRefResponseModel>> PersonRefs(int personBId, int limit = int.MaxValue, int offset = 0)
		{
			List<PersonRef> records = await this.SchemaBPersonRepository.PersonRefs(personBId, limit, offset);

			return this.BolPersonRefMapper.MapBOToModel(this.DalPersonRefMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>0dc5d0a6b8cc1bb984822bc9efc36dc1</Hash>
</Codenesium>*/