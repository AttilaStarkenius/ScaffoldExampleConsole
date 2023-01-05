using System;
using System.Collections.Generic;

namespace ScaffoldExampleConsole;

public partial class Quote
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public int SamuraiId { get; set; }

    public virtual Samurai Samurai { get; set; } = null!;
}
