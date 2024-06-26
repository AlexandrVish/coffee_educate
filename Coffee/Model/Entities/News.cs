﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Model.Entities
{
    public class News
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public DateTime Date { get; set; }
        public string? AuthorId { get; set; }
        public User? Author { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }

    }
}
