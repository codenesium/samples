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
	public abstract class AbstractLifecycleService : AbstractService
	{
		protected ILifecycleRepository LifecycleRepository { get; private set; }

		protected IApiLifecycleRequestModelValidator LifecycleModelValidator { get; private set; }

		protected IBOLLifecycleMapper BolLifecycleMapper { get; private set; }

		protected IDALLifecycleMapper DalLifecycleMapper { get; private set; }

		private ILogger logger;

		public AbstractLifecycleService(
			ILogger logger,
			ILifecycleRepository lifecycleRepository,
			IApiLifecycleRequestModelValidator lifecycleModelValidator,
			IBOLLifecycleMapper bolLifecycleMapper,
			IDALLifecycleMapper dalLifecycleMapper)
			: base()
		{
			this.LifecycleRepository = lifecycleRepository;
			this.LifecycleModelValidator = lifecycleModelValidator;
			this.BolLifecycleMapper = bolLifecycleMapper;
			this.DalLifecycleMapper = dalLifecycleMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiLifecycleResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.LifecycleRepository.All(limit, offset);

			return this.BolLifecycleMapper.MapBOToModel(this.DalLifecycleMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiLifecycleResponseModel> Get(string id)
		{
			var record = await this.LifecycleRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLifecycleMapper.MapBOToModel(this.DalLifecycleMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiLifecycleResponseModel>> Create(
			ApiLifecycleRequestModel model)
		{
			CreateResponse<ApiLifecycleResponseModel> response = new CreateResponse<ApiLifecycleResponseModel>(await this.LifecycleModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolLifecycleMapper.MapModelToBO(default(string), model);
				var record = await this.LifecycleRepository.Create(this.DalLifecycleMapper.MapBOToEF(bo));

				response.SetRecord(this.BolLifecycleMapper.MapBOToModel(this.DalLifecycleMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiLifecycleResponseModel>> Update(
			string id,
			ApiLifecycleRequestModel model)
		{
			var validationResult = await this.LifecycleModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolLifecycleMapper.MapModelToBO(id, model);
				await this.LifecycleRepository.Update(this.DalLifecycleMapper.MapBOToEF(bo));

				var record = await this.LifecycleRepository.Get(id);

				return new UpdateResponse<ApiLifecycleResponseModel>(this.BolLifecycleMapper.MapBOToModel(this.DalLifecycleMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiLifecycleResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.LifecycleModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.LifecycleRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiLifecycleResponseModel> ByName(string name)
		{
			Lifecycle record = await this.LifecycleRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolLifecycleMapper.MapBOToModel(this.DalLifecycleMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiLifecycleResponseModel>> ByDataVersion(byte[] dataVersion, int limit = 0, int offset = int.MaxValue)
		{
			List<Lifecycle> records = await this.LifecycleRepository.ByDataVersion(dataVersion, limit, offset);

			return this.BolLifecycleMapper.MapBOToModel(this.DalLifecycleMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>283ca94c2c2eaf07ed5a02d226aafae0</Hash>
</Codenesium>*/