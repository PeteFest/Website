using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PeteFest.Data.DataObjects;
using PeteFest.Web.Mapping.Base;
using PeteFest.Web.Models.Festival;

namespace PeteFest.Web.Mapping
{
    public class TicketsModelMapper : ModelMapper<TicketsModel, TicketInfoContact>, ITicketsModelMapper
    {
    }
}