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
		private MediatR.IMediator mediator;

		protected IColumnSameAsFKTableRepository ColumnSameAsFKTableRepository { get; private set; }

		protected IApiColumnSameAsFKTableServerRequestModelValidator ColumnSameAsFKTableModelValidator { get; private set; }

		protected IDALColumnSameAsFKTableMapper DalColumnSameAsFKTableMapper { get; private set; }

		private ILogger logger;

		public AbstractColumnSameAsFKTableService(
			ILogger logger,
			MediatR.IMediator mediator,
			IColumnSameAsFKTableRepository columnSameAsFKTableRepository,
			IApiColumnSameAsFKTableServerRequestModelValidator columnSameAsFKTableModelValidator,
			IDALColumnSameAsFKTableMapper dalColumnSameAsFKTableMapper)
			: base()
		{
			this.ColumnSameAsFKTableRepository = columnSameAsFKTableRepository;
			this.ColumnSameAsFKTableModelValidator = columnSameAsFKTableModelValidator;
			this.DalColumnSameAsFKTableMapper = dalColumnSameAsFKTableMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiColumnSameAsFKTableServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<ColumnSameAsFKTable> records = await this.ColumnSameAsFKTableRepository.All(limit, offset, query);

			return this.DalColumnSameAsFKTableMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiColumnSameAsFKTableServerResponseModel> Get(int id)
		{
			ColumnSameAsFKTable record = await this.ColumnSameAsFKTableRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalColumnSameAsFKTableMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiColumnSameAsFKTableServerResponseModel>> Create(
			ApiColumnSameAsFKTableServerRequestModel model)
		{
			CreateResponse<ApiColumnSameAsFKTableServerResponseModel> response = ValidationResponseFactory<ApiColumnSameAsFKTableServerResponseModel>.CreateResponse(await this.ColumnSameAsFKTableModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				ColumnSameAsFKTable record = this.DalColumnSameAsFKTableMapper.MapModelToEntity(default(int), model);
				record = await this.ColumnSameAsFKTableRepository.Create(record);

				response.SetRecord(this.DalColumnSameAsFKTableMapper.MapEntityToModel(record));
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
				ColumnSameAsFKTable record = this.DalColumnSameAsFKTableMapper.MapModelToEntity(id, model);
				await this.ColumnSameAsFKTableRepository.Update(record);

				record = await this.ColumnSameAsFKTableRepository.Get(id);

				ApiColumnSameAsFKTableServerResponseModel apiModel = this.DalColumnSameAsFKTableMapper.MapEntityToModel(record);
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
    <Hash>68795b3240f484a27fbe4a11176317f0</Hash>
</Codenesium>*/