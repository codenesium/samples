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
		private ISchemaBPersonRepository schemaBPersonRepository;

		private IApiSchemaBPersonRequestModelValidator schemaBPersonModelValidator;

		private IBOLSchemaBPersonMapper bolSchemaBPersonMapper;

		private IDALSchemaBPersonMapper dalSchemaBPersonMapper;

		private IBOLPersonRefMapper bolPersonRefMapper;

		private IDALPersonRefMapper dalPersonRefMapper;

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
			this.schemaBPersonRepository = schemaBPersonRepository;
			this.schemaBPersonModelValidator = schemaBPersonModelValidator;
			this.bolSchemaBPersonMapper = bolSchemaBPersonMapper;
			this.dalSchemaBPersonMapper = dalSchemaBPersonMapper;
			this.bolPersonRefMapper = bolPersonRefMapper;
			this.dalPersonRefMapper = dalPersonRefMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSchemaBPersonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.schemaBPersonRepository.All(limit, offset);

			return this.bolSchemaBPersonMapper.MapBOToModel(this.dalSchemaBPersonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSchemaBPersonResponseModel> Get(int id)
		{
			var record = await this.schemaBPersonRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolSchemaBPersonMapper.MapBOToModel(this.dalSchemaBPersonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSchemaBPersonResponseModel>> Create(
			ApiSchemaBPersonRequestModel model)
		{
			CreateResponse<ApiSchemaBPersonResponseModel> response = new CreateResponse<ApiSchemaBPersonResponseModel>(await this.schemaBPersonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolSchemaBPersonMapper.MapModelToBO(default(int), model);
				var record = await this.schemaBPersonRepository.Create(this.dalSchemaBPersonMapper.MapBOToEF(bo));

				response.SetRecord(this.bolSchemaBPersonMapper.MapBOToModel(this.dalSchemaBPersonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSchemaBPersonResponseModel>> Update(
			int id,
			ApiSchemaBPersonRequestModel model)
		{
			var validationResult = await this.schemaBPersonModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolSchemaBPersonMapper.MapModelToBO(id, model);
				await this.schemaBPersonRepository.Update(this.dalSchemaBPersonMapper.MapBOToEF(bo));

				var record = await this.schemaBPersonRepository.Get(id);

				return new UpdateResponse<ApiSchemaBPersonResponseModel>(this.bolSchemaBPersonMapper.MapBOToModel(this.dalSchemaBPersonMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSchemaBPersonResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.schemaBPersonModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.schemaBPersonRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiPersonRefResponseModel>> PersonRefs(int personBId, int limit = int.MaxValue, int offset = 0)
		{
			List<PersonRef> records = await this.schemaBPersonRepository.PersonRefs(personBId, limit, offset);

			return this.bolPersonRefMapper.MapBOToModel(this.dalPersonRefMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>321d584d889fde5b873eb0d9d4eccc7d</Hash>
</Codenesium>*/