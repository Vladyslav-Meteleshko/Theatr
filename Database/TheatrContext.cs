using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class TheatrContext : DbContext {
    public TheatrContext(DbContextOptions<TheatrContext> options)
        : base(options) {
    }

    public DbSet<Scene> Scenes { get; set; }
    public DbSet<Spectacle> Spectacles { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}

public class Scene {
    [Key]
    public int Id { get; set; }
    public DateTime DateCreate { get; set; }
    public string Name { get; set; }
    public string Data { get; set; }

    public virtual ICollection<Spectacle> Spectacle { get; set; }
}

public class Spectacle {
    [Key]
    public int Id { get; set; }
    public DateTime DateCreate { get; set; }
    [ForeignKey("Scene")]
    public int SceneId { get; set; }
    public string Name { get; set; }
    public string Desc { get; set; }
    public DateTime DatePublic { get; set; }

    public virtual Scene Scene { get; set; }

    public virtual ICollection<Ticket> Ticket { get; set; }
}

public class Ticket {
    [Key]
    public int Id { get; set; }
    [ForeignKey("Spectacle")]
    public int SpectacleId { get; set; }
    [ForeignKey("Transaction")]
    public string TransactionId { get; set; }
    public DateTime DateCreate { get; set; }
    public string Seat { get; set; }

    public virtual Spectacle Spectacle { get; set; } 
    public virtual Transaction Transaction { get; set; } 
}

public class Transaction {
    [Key]
    public Guid OrderId { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; }

    public virtual ICollection<Ticket> Ticket { get; set; }
}