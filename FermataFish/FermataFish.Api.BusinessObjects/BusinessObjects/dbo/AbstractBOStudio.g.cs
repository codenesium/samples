using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOStudio: AbstractBOManager
	{
		private IStudioRepository studioRepository;
		private IApiStudioRequestModelValidator studioModelValidator;
		private IBOLStudioMapper studioMapper;
		private ILogger logger;

		public AbstractBOStudio(
			ILogger logger,
			IStudioRepository studioRepository,
			IApiStudioRequestModelValidator studioModelValidator,
			IBOLStudioMapper studioMapper)
			: base()

		{
			this.studioRepository = studioRepository;
			this.studioModelValidator = studioModelValidator;
			this.studioMapper = studioMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiStudioResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.studioRepository.All(skip, take, orderClause);

			return this.studioMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiStudioResponseModel> Get(int id)
		{
			var record = await studioRepository.Get(id);

			return this.studioMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiStudioResponseModel>> Create(
			ApiStudioRequestModel model)
		{
			CreateResponse<ApiStudioResponseModel> response = new CreateResponse<ApiStudioResponseModel>(await this.studioModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.studioMapper.MapModelToDTO(default (int), model);
				var record = await this.studioRepository.Create(dto);

				response.SetRecord(this.studioMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiStudioRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.studioModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.studioMapper.MapModelToDTO(id, model);
				await this.studioRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.studioModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.studioRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>28e7b9bc7198c9255526d500e1abf0b7</Hash>
</Codenesium>*/