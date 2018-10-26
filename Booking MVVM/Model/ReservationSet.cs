namespace Booking_MVVM.Model
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

        public int? Client_Id { get; set; }

        public int? Chambres_Id { get; set; }

        public int keyClient { get; set; }

        public int keyChambre { get; set; }

        public virtual ChambresSet ChambresSet { get; set; }

        public virtual ClientsSet ClientsSet { get; set; }
    }
}
