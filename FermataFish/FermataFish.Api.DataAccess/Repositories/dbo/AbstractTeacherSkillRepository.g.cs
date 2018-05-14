using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractTeacherSkillRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractTeacherSkillRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOTeacherSkill> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOTeacherSkill Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOTeacherSkill Create(
			ApiTeacherSkillModel model)
		{
			TeacherSkill record = new TeacherSkill();

			this.Mapper.TeacherSkillMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<TeacherSkill>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.TeacherSkillMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			ApiTeacherSkillModel model)
		{
			TeacherSkill record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			TeacherSkill record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<TeacherSkill>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOTeacherSkill> Where(Expression<Func<TeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOTeacherSkill> SearchLinqPOCO(Expression<Func<TeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOTeacherSkill> response = new List<POCOTeacherSkill>();
			List<TeacherSkill> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.TeacherSkillMapEFToPOCO(x)));
			return response;
		}

		private List<TeacherSkill> SearchLinqEF(Expression<Func<TeacherSkill, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TeacherSkill.Id)} ASC";
			}
			return this.Context.Set<TeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<TeacherSkill>();
		}

		private List<TeacherSkill> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(TeacherSkill.Id)} ASC";
			}

			return this.Context.Set<TeacherSkill>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<TeacherSkill>();
		}
	}
}

/*<Codenesium>
    <Hash>1da60bbaadc3b6509376f4f429e60d60</Hash>
</Codenesium>*/