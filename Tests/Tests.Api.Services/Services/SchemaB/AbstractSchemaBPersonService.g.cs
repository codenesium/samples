using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractSchemaBPersonService : AbstractService
	{
		protected ISchemaBPersonRepository SchemaBPersonRepository { get; private set; }

		protected IApiSchemaBPersonServerRequestModelValidator SchemaBPersonModelValidator { get; private set; }

		protected IBOLSchemaBPersonMapper BolSchemaBPersonMapper { get; private set; }

		protected IDALSchemaBPersonMapper DalSchemaBPersonMapper { get; private set; }

		private ILogger logger;

		public AbstractSchemaBPersonService(
			ILogger logger,
			ISchemaBPersonRepository schemaBPersonRepository,
			IApiSchemaBPersonServerRequestModelValidator schemaBPersonModelValidator,
			IBOLSchemaBPersonMapper bolSchemaBPersonMapper,
			IDALSchemaBPersonMapper dalSchemaBPersonMapper)
			: base()
		{
			this.SchemaBPersonRepository = schemaBPersonRepository;
			this.SchemaBPersonModelValidator = schemaBPersonModelValidator;
			this.BolSchemaBPersonMapper = bolSchemaBPersonMapper;
			this.DalSchemaBPersonMapper = dalSchemaBPersonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSchemaBPersonServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SchemaBPersonRepository.All(limit, offset);

			return this.BolSchemaBPersonMapper.MapBOToModel(this.DalSchemaBPersonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSchemaBPersonServerResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiSchemaBPersonServerResponseModel>> Create(
			ApiSchemaBPersonServerRequestModel model)
		{
			CreateResponse<ApiSchemaBPersonServerResponseModel> response = ValidationResponseFactory<ApiSchemaBPersonServerResponseModel>.CreateResponse(await this.SchemaBPersonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolSchemaBPersonMapper.MapModelToBO(default(int), model);
				var record = await this.SchemaBPersonRepository.Create(this.DalSchemaBPersonMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSchemaBPersonMapper.MapBOToModel(this.DalSchemaBPersonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSchemaBPersonServerResponseModel>> Update(
			int id,
			ApiSchemaBPersonServerRequestModel model)
		{
			var validationResult = await this.SchemaBPersonModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSchemaBPersonMapper.MapModelToBO(id, model);
				await this.SchemaBPersonRepository.Update(this.DalSchemaBPersonMapper.MapBOToEF(bo));

				var record = await this.SchemaBPersonRepository.Get(id);

				return ValidationResponseFactory<ApiSchemaBPersonServerResponseModel>.UpdateResponse(this.BolSchemaBPersonMapper.MapBOToModel(this.DalSchemaBPersonMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiSchemaBPersonServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SchemaBPersonModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.SchemaBPersonRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a9800588386e998c1f719b0cb756a37e</Hash>
</Codenesium>*/