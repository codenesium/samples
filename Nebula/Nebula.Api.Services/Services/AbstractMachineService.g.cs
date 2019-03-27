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
		private MediatR.IMediator mediator;

		protected IMachineRepository MachineRepository { get; private set; }

		protected IApiMachineServerRequestModelValidator MachineModelValidator { get; private set; }

		protected IDALMachineMapper DalMachineMapper { get; private set; }

		protected IDALLinkMapper DalLinkMapper { get; private set; }

		protected IDALMachineRefTeamMapper DalMachineRefTeamMapper { get; private set; }

		private ILogger logger;

		public AbstractMachineService(
			ILogger logger,
			MediatR.IMediator mediator,
			IMachineRepository machineRepository,
			IApiMachineServerRequestModelValidator machineModelValidator,
			IDALMachineMapper dalMachineMapper,
			IDALLinkMapper dalLinkMapper,
			IDALMachineRefTeamMapper dalMachineRefTeamMapper)
			: base()
		{
			this.MachineRepository = machineRepository;
			this.MachineModelValidator = machineModelValidator;
			this.DalMachineMapper = dalMachineMapper;
			this.DalLinkMapper = dalLinkMapper;
			this.DalMachineRefTeamMapper = dalMachineRefTeamMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiMachineServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Machine> records = await this.MachineRepository.All(limit, offset, query);

			return this.DalMachineMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiMachineServerResponseModel> Get(int id)
		{
			Machine record = await this.MachineRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalMachineMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiMachineServerResponseModel>> Create(
			ApiMachineServerRequestModel model)
		{
			CreateResponse<ApiMachineServerResponseModel> response = ValidationResponseFactory<ApiMachineServerResponseModel>.CreateResponse(await this.MachineModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Machine record = this.DalMachineMapper.MapModelToEntity(default(int), model);
				record = await this.MachineRepository.Create(record);

				response.SetRecord(this.DalMachineMapper.MapEntityToModel(record));
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
				Machine record = this.DalMachineMapper.MapModelToEntity(id, model);
				await this.MachineRepository.Update(record);

				record = await this.MachineRepository.Get(id);

				ApiMachineServerResponseModel apiModel = this.DalMachineMapper.MapEntityToModel(record);
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
				return this.DalMachineMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiLinkServerResponseModel>> LinksByAssignedMachineId(int assignedMachineId, int limit = int.MaxValue, int offset = 0)
		{
			List<Link> records = await this.MachineRepository.LinksByAssignedMachineId(assignedMachineId, limit, offset);

			return this.DalLinkMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiMachineRefTeamServerResponseModel>> MachineRefTeamsByMachineId(int machineId, int limit = int.MaxValue, int offset = 0)
		{
			List<MachineRefTeam> records = await this.MachineRepository.MachineRefTeamsByMachineId(machineId, limit, offset);

			return this.DalMachineRefTeamMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>78d4d5a25459f6713bf2ef7fc87f2cef</Hash>
</Codenesium>*/