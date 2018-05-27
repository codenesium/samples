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
	public abstract class AbstractBOSpace: AbstractBOManager
	{
		private ISpaceRepository spaceRepository;
		private IApiSpaceRequestModelValidator spaceModelValidator;
		private IBOLSpaceMapper spaceMapper;
		private ILogger logger;

		public AbstractBOSpace(
			ILogger logger,
			ISpaceRepository spaceRepository,
			IApiSpaceRequestModelValidator spaceModelValidator,
			IBOLSpaceMapper spaceMapper)
			: base()

		{
			this.spaceRepository = spaceRepository;
			this.spaceModelValidator = spaceModelValidator;
			this.spaceMapper = spaceMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSpaceResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.spaceRepository.All(skip, take, orderClause);

			return this.spaceMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiSpaceResponseModel> Get(int id)
		{
			var record = await spaceRepository.Get(id);

			return this.spaceMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiSpaceResponseModel>> Create(
			ApiSpaceRequestModel model)
		{
			CreateResponse<ApiSpaceResponseModel> response = new CreateResponse<ApiSpaceResponseModel>(await this.spaceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.spaceMapper.MapModelToDTO(default (int), model);
				var record = await this.spaceRepository.Create(dto);

				response.SetRecord(this.spaceMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiSpaceRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.spaceModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.spaceMapper.MapModelToDTO(id, model);
				await this.spaceRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.spaceModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.spaceRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ddfcd8627c248618d5781c5e564cbb90</Hash>
</Codenesium>*/