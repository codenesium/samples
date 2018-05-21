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
	public abstract class AbstractTeacherXTeacherSkillRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractTeacherXTeacherSkillRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOTeacherXTeacherSkill>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOTeacherXTeacherSkill> Get(int id)
		{
			TeacherXTeacherSkill record = await this.GetById(id);

			return this.Mapper.TeacherXTeacherSkillMapEFToPOCO(record);
		}

		public async virtual Task<POCOTeacherXTeacherSkill> Create(
			ApiTeacherXTeacherSkillModel model)
		{
			TeacherXTeacherSkill record = new TeacherXTeacherSkill();

			this.Mapper.TeacherXTeacherSkillMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<TeacherXTeacherSkill>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.TeacherXTeacherSkillMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiTeacherXTeacherSkillModel model)
		{
			TeacherXTeacherSkill record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.TeacherXTeacherSkillMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int id)
		{
			TeacherXTeacherSkill record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<TeacherXTeacherSkill>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOTeacherXTeacherSkill>> Where(Expression<Func<TeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOTeacherXTeacherSkill> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOTeacherXTeacherSkill>> SearchLinqPOCO(Expression<Func<TeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOTeacherXTeacherSkill> response = new List<POCOTeacherXTeacherSkill>();
			List<TeacherXTeacherSkill> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.TeacherXTeacherSkillMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<TeacherXTeacherSkill>> SearchLinqEF(Expression<Func<TeacherXTeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TeacherXTeacherSkill.Id)} ASC";
			}
			return await this.Context.Set<TeacherXTeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TeacherXTeacherSkill>();
		}

		private async Task<List<TeacherXTeacherSkill>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TeacherXTeacherSkill.Id)} ASC";
			}

			return await this.Context.Set<TeacherXTeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<TeacherXTeacherSkill>();
		}

		private async Task<TeacherXTeacherSkill> GetById(int id)
		{
			List<TeacherXTeacherSkill> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>46882605fd22b68f1c4045b4303b642b</Hash>
</Codenesium>*/