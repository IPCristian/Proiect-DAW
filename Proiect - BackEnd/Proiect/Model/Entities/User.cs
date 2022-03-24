﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Model.Entities
{
	public class User
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Subscription Subscription { get; set; }
		public ICollection<Playlist> Playlists { get; set; }
	}
}