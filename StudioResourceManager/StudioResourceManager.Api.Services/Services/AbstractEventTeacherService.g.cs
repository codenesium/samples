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
	public abstract class AbstractEventTeacherService : AbstractService
	{
		protected IEventTeacherRepository EventTeacherRepository { get; private set; }

		protected IApiEventTeacherRequestModelValidator EventTeacherModelValidator { get; private set; }

		protected IBOLEventTeacherMapper BolEventTeacherMapper { get; private set; }

		protected IDALEventTeacherMapper DalEventTeacherMapper { get; private set; }

		private ILogger logger;

		public AbstractEventTeacherService(
			ILogger logger,
			IEventTeacherRepository eventTeacherRepository,
			IApiEventTeacherRequestModelValidator eventTeacherModelValidator,
			IBOLEventTeacherMapper bolEventTeacherMapper,
			IDALEventTeacherMapper dalEventTeacherMapper)
			: base()
		{
			this.EventTeacherRepository = eventTeacherRepository;
			this.EventTeacherModelValidator = eventTeacherModelValidator;
			this.BolEventTeacherMapper = bolEventTeacherMapper;
			this.DalEventTeacherMapper = dalEventTeacherMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiEventTeacherResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.EventTeacherRepository.All(limit, offset);

			return this.BolEventTeacherMapper.MapBOToModel(this.DalEventTeacherMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiEventTeacherResponseModel> Get(int eventId)
		{
			var record = await this.EventTeacherRepository.Get(eventId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolEventTeacherMapper.MapBOToModel(this.DalEventTeacherMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiEventTeacherResponseModel>> Create(
			ApiEventTeacherRequestModel model)
		{
			CreateResponse<ApiEventTeacherResponseModel> response = new CreateResponse<ApiEventTeacherResponseModel>(await this.EventTeacherModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolEventTeacherMapper.MapModelToBO(default(int), model);
				var record = await this.EventTeacherRepository.Create(this.DalEventTeacherMapper.MapBOToEF(bo));

				response.SetRecord(this.BolEventTeacherMapper.MapBOToModel(this.DalEventTeacherMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiEventTeacherResponseModel>> Update(
			int eventId,
			ApiEventTeacherRequestModel model)
		{
			var validationResult = await this.EventTeacherModelValidator.ValidateUpdateAsync(eventId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolEventTeacherMapper.MapModelToBO(eventId, model);
				await this.EventTeacherRepository.Update(this.DalEventTeacherMapper.MapBOToEF(bo));

				var record = await this.EventTeacherRepository.Get(eventId);

				return new UpdateResponse<ApiEventTeacherResponseModel>(this.BolEventTeacherMapper.MapBOToModel(this.DalEventTeacherMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiEventTeacherResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int eventId)
		{
			ActionResponse response = new ActionResponse(await this.EventTeacherModelValidator.ValidateDeleteAsync(eventId));
			if (response.Success)
			{
				await this.EventTeacherRepository.Delete(eventId);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1ee5f89605c04a74af8c1874ef440a46</Hash>
</Codenesium>*/