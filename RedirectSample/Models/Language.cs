using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RedirectSample.Models
{
    public enum Language : byte
    {
        [DescriptionAttribute("")]
        None = 0,
        [DescriptionAttribute("en-us")]
        English = 1,
        [DescriptionAttribute("fr-ca")]
        French = 2
    }
}