//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _18_Jun_2021.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public int Id { get; set; }
        public string MessageTitle { get; set; }
        public string MessageContent { get; set; }
        public string ToStation { get; set; }
        public string PosterName { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Count { get; set; }
    }
}
