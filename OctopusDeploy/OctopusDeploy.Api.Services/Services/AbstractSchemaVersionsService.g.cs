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
	public abstract class AbstractSchemaVersionsService : AbstractService
	{
		protected ISchemaVersionsRepository SchemaVersionsRepository { get; private set; }

		protected IApiSchemaVersionsRequestModelValidator SchemaVersionsModelValidator { get; private set; }

		protected IBOLSchemaVersionsMapper BolSchemaVersionsMapper { get; private set; }

		protected IDALSchemaVersionsMapper DalSchemaVersionsMapper { get; private set; }

		private ILogger logger;

		public AbstractSchemaVersionsService(
			ILogger logger,
			ISchemaVersionsRepository schemaVersionsRepository,
			IApiSchemaVersionsRequestModelValidator schemaVersionsModelValidator,
			IBOLSchemaVersionsMapper bolSchemaVersionsMapper,
			IDALSchemaVersionsMapper dalSchemaVersionsMapper)
			: base()
		{
			this.SchemaVersionsRepository = schemaVersionsRepository;
			this.SchemaVersionsModelValidator = schemaVersionsModelValidator;
			this.BolSchemaVersionsMapper = bolSchemaVersionsMapper;
			this.DalSchemaVersionsMapper = dalSchemaVersionsMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSchemaVersionsResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SchemaVersionsRepository.All(limit, offset);

			return this.BolSchemaVersionsMapper.MapBOToModel(this.DalSchemaVersionsMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSchemaVersionsResponseModel> Get(int id)
		{
			var record = await this.SchemaVersionsRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSchemaVersionsMapper.MapBOToModel(this.DalSchemaVersionsMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSchemaVersionsResponseModel>> Create(
			ApiSchemaVersionsRequestModel model)
		{
			CreateResponse<ApiSchemaVersionsResponseModel> response = new CreateResponse<ApiSchemaVersionsResponseModel>(await this.SchemaVersionsModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSchemaVersionsMapper.MapModelToBO(default(int), model);
				var record = await this.SchemaVersionsRepository.Create(this.DalSchemaVersionsMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSchemaVersionsMapper.MapBOToModel(this.DalSchemaVersionsMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSchemaVersionsResponseModel>> Update(
			int id,
			ApiSchemaVersionsRequestModel model)
		{
			var validationResult = await this.SchemaVersionsModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSchemaVersionsMapper.MapModelToBO(id, model);
				await this.SchemaVersionsRepository.Update(this.DalSchemaVersionsMapper.MapBOToEF(bo));

				var record = await this.SchemaVersionsRepository.Get(id);

				return new UpdateResponse<ApiSchemaVersionsResponseModel>(this.BolSchemaVersionsMapper.MapBOToModel(this.DalSchemaVersionsMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSchemaVersionsResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.SchemaVersionsModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.SchemaVersionsRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>db7ebe81c3c371683dc0fb83f2a531a2</Hash>
</Codenesium>*/