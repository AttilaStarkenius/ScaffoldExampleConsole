using System;
using System.Collections.Generic;

namespace ScaffoldExampleConsole;

public partial class Samurai
{
    public Samurai()
    {
        Quotes = new HashSet<Quote>();
    }
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Quote> Quotes { get; set; }/*} = new List<Quote>();*/
}
