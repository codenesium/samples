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
	public abstract class AbstractBOCulture: AbstractBOManager
	{
		private ICultureRepository cultureRepository;
		private IApiCultureRequestModelValidator cultureModelValidator;
		private IBOLCultureMapper cultureMapper;
		private ILogger logger;

		public AbstractBOCulture(
			ILogger logger,
			ICultureRepository cultureRepository,
			IApiCultureRequestModelValidator cultureModelValidator,
			IBOLCultureMapper cultureMapper)
			: base()

		{
			this.cultureRepository = cultureRepository;
			this.cultureModelValidator = cultureModelValidator;
			this.cultureMapper = cultureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCultureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.cultureRepository.All(skip, take, orderClause);

			return this.cultureMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiCultureResponseModel> Get(string cultureID)
		{
			var record = await cultureRepository.Get(cultureID);

			return this.cultureMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiCultureResponseModel>> Create(
			ApiCultureRequestModel model)
		{
			CreateResponse<ApiCultureResponseModel> response = new CreateResponse<ApiCultureResponseModel>(await this.cultureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.cultureMapper.MapModelToDTO(default (string), model);
				var record = await this.cultureRepository.Create(dto);

				response.SetRecord(this.cultureMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string cultureID,
			ApiCultureRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.cultureModelValidator.ValidateUpdateAsync(cultureID, model));

			if (response.Success)
			{
				var dto = this.cultureMapper.MapModelToDTO(cultureID, model);
				await this.cultureRepository.Update(cultureID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			string cultureID)
		{
			ActionResponse response = new ActionResponse(await this.cultureModelValidator.ValidateDeleteAsync(cultureID));

			if (response.Success)
			{
				await this.cultureRepository.Delete(cultureID);
			}
			return response;
		}

		public async Task<ApiCultureResponseModel> GetName(string name)
		{
			DTOCulture record = await this.cultureRepository.GetName(name);

			return this.cultureMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>c43506b9107c4620129d1b47acd6338b</Hash>
</Codenesium>*/