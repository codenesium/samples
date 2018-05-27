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
	public abstract class AbstractBOFamily: AbstractBOManager
	{
		private IFamilyRepository familyRepository;
		private IApiFamilyRequestModelValidator familyModelValidator;
		private IBOLFamilyMapper familyMapper;
		private ILogger logger;

		public AbstractBOFamily(
			ILogger logger,
			IFamilyRepository familyRepository,
			IApiFamilyRequestModelValidator familyModelValidator,
			IBOLFamilyMapper familyMapper)
			: base()

		{
			this.familyRepository = familyRepository;
			this.familyModelValidator = familyModelValidator;
			this.familyMapper = familyMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiFamilyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.familyRepository.All(skip, take, orderClause);

			return this.familyMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiFamilyResponseModel> Get(int id)
		{
			var record = await familyRepository.Get(id);

			return this.familyMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiFamilyResponseModel>> Create(
			ApiFamilyRequestModel model)
		{
			CreateResponse<ApiFamilyResponseModel> response = new CreateResponse<ApiFamilyResponseModel>(await this.familyModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.familyMapper.MapModelToDTO(default (int), model);
				var record = await this.familyRepository.Create(dto);

				response.SetRecord(this.familyMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiFamilyRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.familyModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.familyMapper.MapModelToDTO(id, model);
				await this.familyRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.familyModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.familyRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bd2d3c2b102a8e6fee56e64abb115469</Hash>
</Codenesium>*/