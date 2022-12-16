namespace ProjetoTurmaFiap
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<Projeto.Data.Contexto.TreinamentoContext>();

            builder.Services.AddScoped<
                Projeto.Data.Interfaces.ITurmaRepositorio,
                Projeto.Data.Repositorio.TurmaRepositorio>();

            builder.Services.AddScoped<
                Projeto.Data.Interfaces.IAlunoRepositorio,
                Projeto.Data.Repositorio.AlunoRepositorio>();

            builder.Services.AddScoped<
                Projeto.Data.Interfaces.IturmaAlunosRepositorio,
                Projeto.Data.Repositorio.TurmaAlunosRepositorio>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MinhaRegraCors",
                    policy =>
                    {
                        policy.AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod();

                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MinhaRegraCors");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}