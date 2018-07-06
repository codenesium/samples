using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiBadgesResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        DateTime date,
                        string name,
                        int userId)
                {
                        this.Id = id;
                        this.Date = date;
                        this.Name = name;
                        this.UserId = userId;
                }

                public DateTime Date { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int UserId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c676c94e3ada88714d96027d70968e81</Hash>
</Codenesium>*/