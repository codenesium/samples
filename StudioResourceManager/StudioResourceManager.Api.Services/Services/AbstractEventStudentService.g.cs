using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractEventStudentService : AbstractService
	{
		protected IEventStudentRepository EventStudentRepository { get; private set; }

		protected IApiEventStudentRequestModelValidator EventStudentModelValidator { get; private set; }

		protected IBOLEventStudentMapper BolEventStudentMapper { get; private set; }

		protected IDALEventStudentMapper DalEventStudentMapper { get; private set; }

		private ILogger logger;

		public AbstractEventStudentService(
			ILogger logger,
			IEventStudentRepository eventStudentRepository,
			IApiEventStudentRequestModelValidator eventStudentModelValidator,
			IBOLEventStudentMapper bolEventStudentMapper,
			IDALEventStudentMapper dalEventStudentMapper)
			: base()
		{
			this.EventStudentRepository = eventStudentRepository;
			this.EventStudentModelValidator = eventStudentModelValidator;
			this.BolEventStudentMapper = bolEventStudentMapper;
			this.DalEventStudentMapper = dalEventStudentMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEventStudentResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EventStudentRepository.All(limit, offset);

			return this.BolEventStudentMapper.MapBOToModel(this.DalEventStudentMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEventStudentResponseModel> Get(int id)
		{
			var record = await this.EventStudentRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolEventStudentMapper.MapBOToModel(this.DalEventStudentMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEventStudentResponseModel>> Create(
			ApiEventStudentRequestModel model)
		{
			CreateResponse<ApiEventStudentResponseModel> response = new CreateResponse<ApiEventStudentResponseModel>(await this.EventStudentModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolEventStudentMapper.MapModelToBO(default(int), model);
				var record = await this.EventStudentRepository.Create(this.DalEventStudentMapper.MapBOToEF(bo));

				response.SetRecord(this.BolEventStudentMapper.MapBOToModel(this.DalEventStudentMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEventStudentResponseModel>> Update(
			int id,
			ApiEventStudentRequestModel model)
		{
			var validationResult = await this.EventStudentModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolEventStudentMapper.MapModelToBO(id, model);
				await this.EventStudentRepository.Update(this.DalEventStudentMapper.MapBOToEF(bo));

				var record = await this.EventStudentRepository.Get(id);

				return new UpdateResponse<ApiEventStudentResponseModel>(this.BolEventStudentMapper.MapBOToModel(this.DalEventStudentMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiEventStudentResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.EventStudentModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.EventStudentRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5e98cd6b3646b0ccbc724530e62efb29</Hash>
</Codenesium>*/