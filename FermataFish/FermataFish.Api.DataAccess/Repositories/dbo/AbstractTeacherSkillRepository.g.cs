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

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractTeacherSkillRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractTeacherSkillRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOTeacherSkill>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOTeacherSkill> Get(int id)
		{
			TeacherSkill record = await this.GetById(id);

			return this.Mapper.TeacherSkillMapEFToPOCO(record);
		}

		public async virtual Task<POCOTeacherSkill> Create(
			ApiTeacherSkillModel model)
		{
			TeacherSkill record = new TeacherSkill();

			this.Mapper.TeacherSkillMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<TeacherSkill>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.TeacherSkillMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiTeacherSkillModel model)
		{
			TeacherSkill record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.TeacherSkillMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			TeacherSkill record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<TeacherSkill>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOTeacherSkill>> Where(Expression<Func<TeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOTeacherSkill> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOTeacherSkill>> SearchLinqPOCO(Expression<Func<TeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOTeacherSkill> response = new List<POCOTeacherSkill>();
			List<TeacherSkill> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.TeacherSkillMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<TeacherSkill>> SearchLinqEF(Expression<Func<TeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TeacherSkill.Id)} ASC";
			}
			return await this.Context.Set<TeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TeacherSkill>();
		}

		private async Task<List<TeacherSkill>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TeacherSkill.Id)} ASC";
			}

			return await this.Context.Set<TeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TeacherSkill>();
		}

		private async Task<TeacherSkill> GetById(int id)
		{
			List<TeacherSkill> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>235af109f0c9c0afe897698f1e0a8783</Hash>
</Codenesium>*/