using MediatR;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractMachineService : AbstractService
	{
		private IMediator mediator;

		protected IMachineRepository MachineRepository { get; private set; }

		protected IApiMachineServerRequestModelValidator MachineModelValidator { get; private set; }

		protected IBOLMachineMapper BolMachineMapper { get; private set; }

		protected IDALMachineMapper DalMachineMapper { get; private set; }

		protected IBOLLinkMapper BolLinkMapper { get; private set; }

		protected IDALLinkMapper DalLinkMapper { get; private set; }

		private ILogger logger;

		public AbstractMachineService(
			ILogger logger,
			IMediator mediator,
			IMachineRepository machineRepository,
			IApiMachineServerRequestModelValidator machineModelValidator,
			IBOLMachineMapper bolMachineMapper,
			IDALMachineMapper dalMachineMapper,
			IBOLLinkMapper bolLinkMapper,
			IDALLinkMapper dalLinkMapper)
			: base()
		{
			this.MachineRepository = machineRepository;
			this.MachineModelValidator = machineModelValidator;
			this.BolMachineMapper = bolMachineMapper;
			this.DalMachineMapper = dalMachineMapper;
			this.BolLinkMapper = bolLinkMapper;
			this.DalLinkMapper = dalLinkMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiMachineServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.MachineRepository.All(limit, offset);

			return this.BolMachineMapper.MapBOToModel(this.DalMachineMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiMachineServerResponseModel> Get(int id)
		{
			var record = await this.MachineRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolMachineMapper.MapBOToModel(this.DalMachineMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiMachineServerResponseModel>> Create(
			ApiMachineServerRequestModel model)
		{
			CreateResponse<ApiMachineServerResponseModel> response = ValidationResponseFactory<ApiMachineServerResponseModel>.CreateResponse(await this.MachineModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolMachineMapper.MapModelToBO(default(int), model);
				var record = await this.MachineRepository.Create(this.DalMachineMapper.MapBOToEF(bo));

				var businessObject = this.DalMachineMapper.MapEFToBO(record);
				response.SetRecord(this.BolMachineMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new MachineCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiMachineServerResponseModel>> Update(
			int id,
			ApiMachineServerRequestModel model)
		{
			var validationResult = await this.MachineModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolMachineMapper.MapModelToBO(id, model);
				await this.MachineRepository.Update(this.DalMachineMapper.MapBOToEF(bo));

				var record = await this.MachineRepository.Get(id);

				var businessObject = this.DalMachineMapper.MapEFToBO(record);
				var apiModel = this.BolMachineMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new MachineUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiMachineServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiMachineServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.MachineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.MachineRepository.Delete(id);

				await this.mediator.Publish(new MachineDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<ApiMachineServerResponseModel> ByMachineGuid(Guid machineGuid)
		{
			Machine record = await this.MachineRepository.ByMachineGuid(machineGuid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolMachineMapper.MapBOToModel(this.DalMachineMapper.MapEFToBO(record));
			}
		}

		public async virtual Task<List<ApiLinkServerResponseModel>> LinksByAssignedMachineId(int assignedMachineId, int limit = int.MaxValue, int offset = 0)
		{
			List<Link> records = await this.MachineRepository.LinksByAssignedMachineId(assignedMachineId, limit, offset);

			return this.BolLinkMapper.MapBOToModel(this.DalLinkMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>e89e1d1185ebd64e4b91138fa8a2628f</Hash>
</Codenesium>*/