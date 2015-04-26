using System;

namespace PeteFest.Web.Models.Base
{
    public abstract class ModelBase
    {
        public string Name { get; set; }

        public Guid Id { get; set; }

        public string GmailId { get; set; }
    }
}