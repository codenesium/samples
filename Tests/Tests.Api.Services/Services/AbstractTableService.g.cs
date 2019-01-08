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

		protected IBOLTableMapper BolTableMapper { get; private set; }

		protected IDALTableMapper DalTableMapper { get; private set; }

		private ILogger logger;

		public AbstractTableService(
			ILogger logger,
			IMediator mediator,
			ITableRepository tableRepository,
			IApiTableServerRequestModelValidator tableModelValidator,
			IBOLTableMapper bolTableMapper,
			IDALTableMapper dalTableMapper)
			: base()
		{
			this.TableRepository = tableRepository;
			this.TableModelValidator = tableModelValidator;
			this.BolTableMapper = bolTableMapper;
			this.DalTableMapper = dalTableMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiTableServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.TableRepository.All(limit, offset);

			return this.BolTableMapper.MapBOToModel(this.DalTableMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiTableServerResponseModel> Get(int id)
		{
			var record = await this.TableRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolTableMapper.MapBOToModel(this.DalTableMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiTableServerResponseModel>> Create(
			ApiTableServerRequestModel model)
		{
			CreateResponse<ApiTableServerResponseModel> response = ValidationResponseFactory<ApiTableServerResponseModel>.CreateResponse(await this.TableModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolTableMapper.MapModelToBO(default(int), model);
				var record = await this.TableRepository.Create(this.DalTableMapper.MapBOToEF(bo));

				var businessObject = this.DalTableMapper.MapEFToBO(record);
				response.SetRecord(this.BolTableMapper.MapBOToModel(businessObject));
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
				var bo = this.BolTableMapper.MapModelToBO(id, model);
				await this.TableRepository.Update(this.DalTableMapper.MapBOToEF(bo));

				var record = await this.TableRepository.Get(id);

				var businessObject = this.DalTableMapper.MapEFToBO(record);
				var apiModel = this.BolTableMapper.MapBOToModel(businessObject);
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
    <Hash>bfe6807d2d7b12895313dd029c420f42</Hash>
</Codenesium>*/