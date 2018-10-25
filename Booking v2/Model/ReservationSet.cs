namespace Booking_v2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReservationSet")]
    public partial class ReservationSet
    {
        public int Id { get; set; }

        public DateTime dateDebut { get; set; }

        public DateTime dateFin { get; set; }

        public int ClientsSetId { get; set; }

        public int ChambresSetId { get; set; }

        public virtual ChambresSet ChambresSet { get; set; }

        public virtual ClientsSet ClientsSet { get; set; }
    }
}
