using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractMachineService : AbstractService
	{
		protected IMachineRepository MachineRepository { get; private set; }

		protected IApiMachineRequestModelValidator MachineModelValidator { get; private set; }

		protected IBOLMachineMapper BolMachineMapper { get; private set; }

		protected IDALMachineMapper DalMachineMapper { get; private set; }

		protected IBOLLinkMapper BolLinkMapper { get; private set; }

		protected IDALLinkMapper DalLinkMapper { get; private set; }

		private ILogger logger;

		public AbstractMachineService(
			ILogger logger,
			IMachineRepository machineRepository,
			IApiMachineRequestModelValidator machineModelValidator,
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
		}

		public virtual async Task<List<ApiMachineResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.MachineRepository.All(limit, offset);

			return this.BolMachineMapper.MapBOToModel(this.DalMachineMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiMachineResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiMachineResponseModel>> Create(
			ApiMachineRequestModel model)
		{
			CreateResponse<ApiMachineResponseModel> response = new CreateResponse<ApiMachineResponseModel>(await this.MachineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolMachineMapper.MapModelToBO(default(int), model);
				var record = await this.MachineRepository.Create(this.DalMachineMapper.MapBOToEF(bo));

				response.SetRecord(this.BolMachineMapper.MapBOToModel(this.DalMachineMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiMachineResponseModel>> Update(
			int id,
			ApiMachineRequestModel model)
		{
			var validationResult = await this.MachineModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolMachineMapper.MapModelToBO(id, model);
				await this.MachineRepository.Update(this.DalMachineMapper.MapBOToEF(bo));

				var record = await this.MachineRepository.Get(id);

				return new UpdateResponse<ApiMachineResponseModel>(this.BolMachineMapper.MapBOToModel(this.DalMachineMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiMachineResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.MachineModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.MachineRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiMachineResponseModel> ByMachineGuid(Guid machineGuid)
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

		public async virtual Task<List<ApiLinkResponseModel>> Links(int assignedMachineId, int limit = int.MaxValue, int offset = 0)
		{
			List<Link> records = await this.MachineRepository.Links(assignedMachineId, limit, offset);

			return this.BolLinkMapper.MapBOToModel(this.DalLinkMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiMachineResponseModel>> ByMachineId(int machineId, int limit = int.MaxValue, int offset = 0)
		{
			List<Machine> records = await this.MachineRepository.ByMachineId(machineId, limit, offset);

			return this.BolMachineMapper.MapBOToModel(this.DalMachineMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>9492ab42e63214edc74c6e3f9ea128dd</Hash>
</Codenesium>*/