using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TuneTalk.Core.Entities;

namespace TuneTalk.Infrastructure.Data;

public class TuneTalkDbContext(DbContextOptions options) : IdentityDbContext<User>(options);