using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractColumnSameAsFKTableService : AbstractService
	{
		private IMediator mediator;

		protected IColumnSameAsFKTableRepository ColumnSameAsFKTableRepository { get; private set; }

		protected IApiColumnSameAsFKTableServerRequestModelValidator ColumnSameAsFKTableModelValidator { get; private set; }

		protected IBOLColumnSameAsFKTableMapper BolColumnSameAsFKTableMapper { get; private set; }

		protected IDALColumnSameAsFKTableMapper DalColumnSameAsFKTableMapper { get; private set; }

		private ILogger logger;

		public AbstractColumnSameAsFKTableService(
			ILogger logger,
			IMediator mediator,
			IColumnSameAsFKTableRepository columnSameAsFKTableRepository,
			IApiColumnSameAsFKTableServerRequestModelValidator columnSameAsFKTableModelValidator,
			IBOLColumnSameAsFKTableMapper bolColumnSameAsFKTableMapper,
			IDALColumnSameAsFKTableMapper dalColumnSameAsFKTableMapper)
			: base()
		{
			this.ColumnSameAsFKTableRepository = columnSameAsFKTableRepository;
			this.ColumnSameAsFKTableModelValidator = columnSameAsFKTableModelValidator;
			this.BolColumnSameAsFKTableMapper = bolColumnSameAsFKTableMapper;
			this.DalColumnSameAsFKTableMapper = dalColumnSameAsFKTableMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiColumnSameAsFKTableServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ColumnSameAsFKTableRepository.All(limit, offset);

			return this.BolColumnSameAsFKTableMapper.MapBOToModel(this.DalColumnSameAsFKTableMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiColumnSameAsFKTableServerResponseModel> Get(int id)
		{
			var record = await this.ColumnSameAsFKTableRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolColumnSameAsFKTableMapper.MapBOToModel(this.DalColumnSameAsFKTableMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiColumnSameAsFKTableServerResponseModel>> Create(
			ApiColumnSameAsFKTableServerRequestModel model)
		{
			CreateResponse<ApiColumnSameAsFKTableServerResponseModel> response = ValidationResponseFactory<ApiColumnSameAsFKTableServerResponseModel>.CreateResponse(await this.ColumnSameAsFKTableModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolColumnSameAsFKTableMapper.MapModelToBO(default(int), model);
				var record = await this.ColumnSameAsFKTableRepository.Create(this.DalColumnSameAsFKTableMapper.MapBOToEF(bo));

				var businessObject = this.DalColumnSameAsFKTableMapper.MapEFToBO(record);
				response.SetRecord(this.BolColumnSameAsFKTableMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new ColumnSameAsFKTableCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiColumnSameAsFKTableServerResponseModel>> Update(
			int id,
			ApiColumnSameAsFKTableServerRequestModel model)
		{
			var validationResult = await this.ColumnSameAsFKTableModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolColumnSameAsFKTableMapper.MapModelToBO(id, model);
				await this.ColumnSameAsFKTableRepository.Update(this.DalColumnSameAsFKTableMapper.MapBOToEF(bo));

				var record = await this.ColumnSameAsFKTableRepository.Get(id);

				var businessObject = this.DalColumnSameAsFKTableMapper.MapEFToBO(record);
				var apiModel = this.BolColumnSameAsFKTableMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new ColumnSameAsFKTableUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiColumnSameAsFKTableServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiColumnSameAsFKTableServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ColumnSameAsFKTableModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.ColumnSameAsFKTableRepository.Delete(id);

				await this.mediator.Publish(new ColumnSameAsFKTableDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d633dfdc282a48644c7cbb4ad4c723fe</Hash>
</Codenesium>*/