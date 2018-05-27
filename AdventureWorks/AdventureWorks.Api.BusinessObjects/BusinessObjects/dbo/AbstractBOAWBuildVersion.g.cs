using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOAWBuildVersion: AbstractBOManager
	{
		private IAWBuildVersionRepository aWBuildVersionRepository;
		private IApiAWBuildVersionRequestModelValidator aWBuildVersionModelValidator;
		private IBOLAWBuildVersionMapper aWBuildVersionMapper;
		private ILogger logger;

		public AbstractBOAWBuildVersion(
			ILogger logger,
			IAWBuildVersionRepository aWBuildVersionRepository,
			IApiAWBuildVersionRequestModelValidator aWBuildVersionModelValidator,
			IBOLAWBuildVersionMapper aWBuildVersionMapper)
			: base()

		{
			this.aWBuildVersionRepository = aWBuildVersionRepository;
			this.aWBuildVersionModelValidator = aWBuildVersionModelValidator;
			this.aWBuildVersionMapper = aWBuildVersionMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiAWBuildVersionResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.aWBuildVersionRepository.All(skip, take, orderClause);

			return this.aWBuildVersionMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiAWBuildVersionResponseModel> Get(int systemInformationID)
		{
			var record = await aWBuildVersionRepository.Get(systemInformationID);

			return this.aWBuildVersionMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiAWBuildVersionResponseModel>> Create(
			ApiAWBuildVersionRequestModel model)
		{
			CreateResponse<ApiAWBuildVersionResponseModel> response = new CreateResponse<ApiAWBuildVersionResponseModel>(await this.aWBuildVersionModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.aWBuildVersionMapper.MapModelToDTO(default (int), model);
				var record = await this.aWBuildVersionRepository.Create(dto);

				response.SetRecord(this.aWBuildVersionMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int systemInformationID,
			ApiAWBuildVersionRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.aWBuildVersionModelValidator.ValidateUpdateAsync(systemInformationID, model));

			if (response.Success)
			{
				var dto = this.aWBuildVersionMapper.MapModelToDTO(systemInformationID, model);
				await this.aWBuildVersionRepository.Update(systemInformationID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int systemInformationID)
		{
			ActionResponse response = new ActionResponse(await this.aWBuildVersionModelValidator.ValidateDeleteAsync(systemInformationID));

			if (response.Success)
			{
				await this.aWBuildVersionRepository.Delete(systemInformationID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4279f4351cb35ff0c1583ed1a8e8e2a2</Hash>
</Codenesium>*/