using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractSchemaAPersonService : AbstractService
	{
		private IMediator mediator;

		protected ISchemaAPersonRepository SchemaAPersonRepository { get; private set; }

		protected IApiSchemaAPersonServerRequestModelValidator SchemaAPersonModelValidator { get; private set; }

		protected IBOLSchemaAPersonMapper BolSchemaAPersonMapper { get; private set; }

		protected IDALSchemaAPersonMapper DalSchemaAPersonMapper { get; private set; }

		private ILogger logger;

		public AbstractSchemaAPersonService(
			ILogger logger,
			IMediator mediator,
			ISchemaAPersonRepository schemaAPersonRepository,
			IApiSchemaAPersonServerRequestModelValidator schemaAPersonModelValidator,
			IBOLSchemaAPersonMapper bolSchemaAPersonMapper,
			IDALSchemaAPersonMapper dalSchemaAPersonMapper)
			: base()
		{
			this.SchemaAPersonRepository = schemaAPersonRepository;
			this.SchemaAPersonModelValidator = schemaAPersonModelValidator;
			this.BolSchemaAPersonMapper = bolSchemaAPersonMapper;
			this.DalSchemaAPersonMapper = dalSchemaAPersonMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiSchemaAPersonServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SchemaAPersonRepository.All(limit, offset);

			return this.BolSchemaAPersonMapper.MapBOToModel(this.DalSchemaAPersonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSchemaAPersonServerResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiSchemaAPersonServerResponseModel>> Create(
			ApiSchemaAPersonServerRequestModel model)
		{
			CreateResponse<ApiSchemaAPersonServerResponseModel> response = ValidationResponseFactory<ApiSchemaAPersonServerResponseModel>.CreateResponse(await this.SchemaAPersonModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolSchemaAPersonMapper.MapModelToBO(default(int), model);
				var record = await this.SchemaAPersonRepository.Create(this.DalSchemaAPersonMapper.MapBOToEF(bo));

				var businessObject = this.DalSchemaAPersonMapper.MapEFToBO(record);
				response.SetRecord(this.BolSchemaAPersonMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new SchemaAPersonCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSchemaAPersonServerResponseModel>> Update(
			int id,
			ApiSchemaAPersonServerRequestModel model)
		{
			var validationResult = await this.SchemaAPersonModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSchemaAPersonMapper.MapModelToBO(id, model);
				await this.SchemaAPersonRepository.Update(this.DalSchemaAPersonMapper.MapBOToEF(bo));

				var record = await this.SchemaAPersonRepository.Get(id);

				var businessObject = this.DalSchemaAPersonMapper.MapEFToBO(record);
				var apiModel = this.BolSchemaAPersonMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new SchemaAPersonUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiSchemaAPersonServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiSchemaAPersonServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.SchemaAPersonModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.SchemaAPersonRepository.Delete(id);

				await this.mediator.Publish(new SchemaAPersonDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dff8bc59b2be5ece82b82c7aa7b1ad95</Hash>
</Codenesium>*/