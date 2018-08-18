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
	public abstract class AbstractSchemaAPersonService : AbstractService
	{
		protected ISchemaAPersonRepository SchemaAPersonRepository { get; private set; }

		protected IApiSchemaAPersonRequestModelValidator SchemaAPersonModelValidator { get; private set; }

		protected IBOLSchemaAPersonMapper BolSchemaAPersonMapper { get; private set; }

		protected IDALSchemaAPersonMapper DalSchemaAPersonMapper { get; private set; }

		private ILogger logger;

		public AbstractSchemaAPersonService(
			ILogger logger,
			ISchemaAPersonRepository schemaAPersonRepository,
			IApiSchemaAPersonRequestModelValidator schemaAPersonModelValidator,
			IBOLSchemaAPersonMapper bolSchemaAPersonMapper,
			IDALSchemaAPersonMapper dalSchemaAPersonMapper)
			: base()
		{
			this.SchemaAPersonRepository = schemaAPersonRepository;
			this.SchemaAPersonModelValidator = schemaAPersonModelValidator;
			this.BolSchemaAPersonMapper = bolSchemaAPersonMapper;
			this.DalSchemaAPersonMapper = dalSchemaAPersonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSchemaAPersonResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SchemaAPersonRepository.All(limit, offset);

			return this.BolSchemaAPersonMapper.MapBOToModel(this.DalSchemaAPersonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSchemaAPersonResponseModel> Get(int id)
		{
			var record = await this.SchemaAPersonRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSchemaAPersonMapper.MapBOToModel(this.DalSchemaAPersonMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSchemaAPersonResponseModel>> Create(
			ApiSchemaAPersonRequestModel model)
		{
			CreateResponse<ApiSchemaAPersonResponseModel> response = new CreateResponse<ApiSchemaAPersonResponseModel>(await this.SchemaAPersonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSchemaAPersonMapper.MapModelToBO(default(int), model);
				var record = await this.SchemaAPersonRepository.Create(this.DalSchemaAPersonMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSchemaAPersonMapper.MapBOToModel(this.DalSchemaAPersonMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSchemaAPersonResponseModel>> Update(
			int id,
			ApiSchemaAPersonRequestModel model)
		{
			var validationResult = await this.SchemaAPersonModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSchemaAPersonMapper.MapModelToBO(id, model);
				await this.SchemaAPersonRepository.Update(this.DalSchemaAPersonMapper.MapBOToEF(bo));

				var record = await this.SchemaAPersonRepository.Get(id);

				return new UpdateResponse<ApiSchemaAPersonResponseModel>(this.BolSchemaAPersonMapper.MapBOToModel(this.DalSchemaAPersonMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSchemaAPersonResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.SchemaAPersonModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.SchemaAPersonRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cb34871847ba1ae643d784a2e6b04e71</Hash>
</Codenesium>*/