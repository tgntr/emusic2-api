﻿using SimpleMusicStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SimpleMusicStore.Entities
{
    public class Record : EntityWithCustomId<int>
    {
        public Record()
        {
            Videos = new List<Video>();
            Tracklist = new List<Track>();
            WishedBy = new List<Wish>();
            Orders = new List<Item>();
            DateAdded = DateTime.UtcNow;
            IsActive = true;
        }

        [Required]
        public string Title { get; set; }

        [Url]
        public string Image { get; set; } 

        //TODO should genre be an entity?
        public string Genre { get; set; }

        [Required]
        public int Year { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 100)]
        public decimal Price { get; set; }

        //todo make this work
        public int Quantity => Stocks.Sum(s => s.Quantity) - Orders.Sum(o => o.Quantity);

        public string Format { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }

        [Required]
        public int LabelId { get; set; }
        public virtual Label Label { get; set; }
        
        public virtual ICollection<Wish> WishedBy { get; set; }
        public virtual ICollection<Item> Orders { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
        public virtual ICollection<Track> Tracklist { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public int Popularity => (Orders.Sum(o => o.Quantity) * 2) + WishedBy.Count;
    }
}
