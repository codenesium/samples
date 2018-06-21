using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingCRMNS.Api.DataAccess
{
        [Table("TransactionStatus", Schema="dbo")]
        public partial class TransactionStatus : AbstractEntity
        {
                public TransactionStatus()
                {
                }

                public void SetProperties(
                        int id,
                        string name)
                {
                        this.Id = id;
                        this.Name = name;
                }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b7255bf0a46e4d4ffaab6524ede4d419</Hash>
</Codenesium>*/