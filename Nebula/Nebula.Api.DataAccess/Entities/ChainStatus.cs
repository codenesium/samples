using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NebulaNS.Api.DataAccess
{
        [Table("ChainStatus", Schema="dbo")]
        public partial class ChainStatus : AbstractEntity
        {
                public ChainStatus()
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
    <Hash>ad8130724486816787b04b4ae3aa1e33</Hash>
</Codenesium>*/