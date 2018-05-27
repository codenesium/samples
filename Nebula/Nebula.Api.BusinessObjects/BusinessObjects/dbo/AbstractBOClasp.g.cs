using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOClasp: AbstractBOManager
	{
		private IClaspRepository claspRepository;
		private IApiClaspRequestModelValidator claspModelValidator;
		private IBOLClaspMapper claspMapper;
		private ILogger logger;

		public AbstractBOClasp(
			ILogger logger,
			IClaspRepository claspRepository,
			IApiClaspRequestModelValidator claspModelValidator,
			IBOLClaspMapper claspMapper)
			: base()

		{
			this.claspRepository = claspRepository;
			this.claspModelValidator = claspModelValidator;
			this.claspMapper = claspMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiClaspResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.claspRepository.All(skip, take, orderClause);

			return this.claspMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiClaspResponseModel> Get(int id)
		{
			var record = await claspRepository.Get(id);

			return this.claspMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiClaspResponseModel>> Create(
			ApiClaspRequestModel model)
		{
			CreateResponse<ApiClaspResponseModel> response = new CreateResponse<ApiClaspResponseModel>(await this.claspModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.claspMapper.MapModelToDTO(default (int), model);
				var record = await this.claspRepository.Create(dto);

				response.SetRecord(this.claspMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiClaspRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.claspModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.claspMapper.MapModelToDTO(id, model);
				await this.claspRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.claspModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.claspRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c49466214dc907999f76fde61aa0129a</Hash>
</Codenesium>*/