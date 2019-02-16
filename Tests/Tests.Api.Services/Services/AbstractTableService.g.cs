using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractTableService : AbstractService
	{
		private IMediator mediator;

		protected ITableRepository TableRepository { get; private set; }

		protected IApiTableServerRequestModelValidator TableModelValidator { get; private set; }

		protected IDALTableMapper DalTableMapper { get; private set; }

		private ILogger logger;

		public AbstractTableService(
			ILogger logger,
			IMediator mediator,
			ITableRepository tableRepository,
			IApiTableServerRequestModelValidator tableModelValidator,
			IDALTableMapper dalTableMapper)
			: base()
		{
			this.TableRepository = tableRepository;
			this.TableModelValidator = tableModelValidator;
			this.DalTableMapper = dalTableMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTableServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Table> records = await this.TableRepository.All(limit, offset, query);

			return this.DalTableMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiTableServerResponseModel> Get(int id)
		{
			Table record = await this.TableRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalTableMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiTableServerResponseModel>> Create(
			ApiTableServerRequestModel model)
		{
			CreateResponse<ApiTableServerResponseModel> response = ValidationResponseFactory<ApiTableServerResponseModel>.CreateResponse(await this.TableModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Table record = this.DalTableMapper.MapModelToEntity(default(int), model);
				record = await this.TableRepository.Create(record);

				response.SetRecord(this.DalTableMapper.MapEntityToModel(record));
				await this.mediator.Publish(new TableCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiTableServerResponseModel>> Update(
			int id,
			ApiTableServerRequestModel model)
		{
			var validationResult = await this.TableModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Table record = this.DalTableMapper.MapModelToEntity(id, model);
				await this.TableRepository.Update(record);

				record = await this.TableRepository.Get(id);

				ApiTableServerResponseModel apiModel = this.DalTableMapper.MapEntityToModel(record);
				await this.mediator.Publish(new TableUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiTableServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiTableServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.TableModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.TableRepository.Delete(id);

				await this.mediator.Publish(new TableDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>48b01f24026c7dbd81ffda03ac23303a</Hash>
</Codenesium>*/